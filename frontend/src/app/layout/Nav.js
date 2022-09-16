import React, { useContext } from 'react'
import { AppContext } from '../../features/Context/AppProvider';
import NotifyItem from "./NotifyItem"

function Nav() {

    const { userInfo, countNotification,
        listNotification, isToggle, setIsToggle } = useContext(AppContext);

    const handleLogout = () => {
        localStorage.removeItem("vinhlab_accessToken");
        window.location.reload();
    }

    const toggleListNotify = () => {
        setIsToggle(!isToggle);
        console.log(isToggle);
    }

    return (
        <div className="nav">
            <h3>LAB TRAINNING</h3>
            <ul className="nav-list">
                <li><a href="#" className="nav-link">Welcome {userInfo.username}</a></li>

                <li>
                    <h5 href="" className="nav-link" onClick={toggleListNotify}>Notifications
                        {(countNotification > 0) && <span className="nav-counter">{countNotification}</span>}
                    </h5>
                    {isToggle &&
                        <div className="notify-dropdown">
                            {listNotification.map(notify => <NotifyItem notify={notify} />)}
                        </div>}
                </li>

                <li><a href="#" className="nav-link" onClick={handleLogout}>Logout</a></li>
            </ul>
        </div>
    )
}

export default Nav