import React, { useState, useEffect, useContext, useMemo } from 'react'
import { useNavigate } from 'react-router-dom';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { AppContext } from "../Context/AppProvider"
import axios from "axios"
import { toast } from "react-toastify"

function Home() {
    let navigate = useNavigate();

    const { userInfo, setCountNotification,
        listNotification, setListNotification } = useContext(AppContext)
    const [connection, setConnection] = useState(null);

    const [notify, setNotify] = useState({
        title: "",
        content: "",
        userId: localStorage.getItem("vinhlab_userid")
    });

    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
            .withUrl('https://localhost:44383/chat')
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, []);

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(result => {
                    console.log('Connected!');

                    connection.on('ReceiveNotification', message => {
                        console.log(message);
                        setCountNotification(prev => prev + 1)
                    });

                    connection.on('HasBeenCheckedNewNotify', data => {
                        if (data.length > listNotification.length) {
                            setCountNotification(data.length)
                            setListNotification(data)
                        }
                    });
                })
                .catch(e => console.log('Connection failed: ', e));
        }
    }, [connection]);

    // check authen
    useEffect(() => {
        !localStorage.getItem("vinhlab_accessToken") && navigate("/login");   // ko có token thì redirect to login
    }, []);

    useEffect(() => {
        axios.get(`https://localhost:44383/Notify/getByUserId?userId=${userInfo.userId}`)
            .then(res => {
                setListNotification(res.data.data)
                setCountNotification(res.data.data.length)
            })
            .catch(e => console.log('Error: ', e));
    }, []);

    useEffect(() => {
        setInterval(async () => {
            if (connection)
                await connection.send('CheckNewNotify', localStorage.getItem("vinhlab_userid"));
        }, 10000);
    }, [connection]);

    const handlePushNotification = async () => {
        // axios.post("https://localhost:44383/Notify", notify)
        //     .then(res => {
        //         if (res.data.isSuccessed) {
        //             toast.success(res.data.message)
        //             setNotify({ title: "", content: "" });
        //         } else {
        //             toast.error(res.data.message)
        //         }
        //     })
        //     .catch(err => console.log(err))

        if (connection) {
            try {
                await connection.send('SendNotification', notify);
                setListNotification([...listNotification, notify]);
                setNotify({ title: "", content: "" });
            }
            catch (e) {
                console.log(e);
            }
        }
        else {
            alert('No connection to server yet.');
        }
    }

    return (
        <div>
            <h2 className="form_title">Send Notification</h2>
            <div className="form_input">
                <input type="text" placeholder="Input a title..." name="title" value={notify.title}
                    onChange={(e) => setNotify({ ...notify, title: e.target.value })} />
                <input type="text" placeholder="Input a content..." name="content" value={notify.content}
                    onChange={(e) => setNotify({ ...notify, content: e.target.value })} />
                <button onClick={handlePushNotification}>Push</button>
            </div>
        </div>
    )
}

export default Home