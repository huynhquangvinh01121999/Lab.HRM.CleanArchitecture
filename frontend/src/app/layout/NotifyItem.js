import React from 'react'

function NotifyItem({ notify }) {
    return (
        <>
            <span style={{ color: "black", marginBottom: "2px" }}>{notify.title}</span><br />
            <span style={{ color: "rgb(136, 133, 133)", marginBottom: "2px", fontSize: "10px" }}>{notify.created}</span>
            <br />
        </>
    )
}

export default NotifyItem