import React, { useState, useContext, useEffect } from 'react'
import { toast } from 'react-toastify';
import axios from "axios"
import { AppContext } from '../Context/AppProvider';
import { useNavigate } from 'react-router-dom';

function Login() {
    let navigate = useNavigate();

    const [user, setUser] = useState({
        userName: "",
        passWord: ""
    });

    // check authen
    useEffect(() => {
        localStorage.getItem("vinhlab_accessToken") && navigate("/");   // có token thì redirect to homepage
    }, [])

    const { setUserInfo } = useContext(AppContext);

    const handleSubmitLogin = () => {
        axios.post("https://localhost:44383/Users/authenticate", user)
            .then(res => {
                if (res.data.isSuccessed) {
                    localStorage.setItem("vinhlab_accessToken", res.data.data.accessToken);
                    localStorage.setItem("vinhlab_userid", res.data.data.userId);

                    setUserInfo(res.data.data)

                    toast.success(res.data.message)

                    console.log(res.data.data);

                    // chỉ thay đổi url chứ ko push lại làm refresh data context
                    navigate('/', { replace: true });
                } else {
                    toast.error(res.data.message)
                }
            })
            .catch(err => console.log(err))
    }

    return (
        <>
            <h2 className="form_title">LOGIN SYSTEM</h2>
            <div className="form_input">
                <input type="text" placeholder="Input your username..."
                    name="userName"
                    onChange={(e) => setUser({ ...user, userName: e.target.value })} />
                <input type="password" placeholder="Input your password..."
                    name="passWord"
                    onChange={(e) => setUser({ ...user, passWord: e.target.value })} />
                <button onClick={handleSubmitLogin}>Login</button>
            </div>
        </>
    )
}

export default Login