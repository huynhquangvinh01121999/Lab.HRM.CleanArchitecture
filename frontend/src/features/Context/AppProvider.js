import { createContext, useContext, useState } from "react";

export const AppContext = createContext()

function AppProvider({ children }) {

    const [userInfo, setUserInfo] = useState({});
    const [countNotification, setCountNotification] = useState(0);
    const [listNotification, setListNotification] = useState([]);
    const [isToggle, setIsToggle] = useState(false);

    return (
        <AppContext.Provider value={{
            userInfo, setUserInfo,
            countNotification, setCountNotification,
            listNotification, setListNotification,
            isToggle, setIsToggle
        }}>
            {children}
        </AppContext.Provider>
    )
}

export default AppProvider