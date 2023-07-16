import { useState } from "react";
export const UseAuth = (apiBaseUrl: string) => {
    const [AuthState, SetAuthState] = useState(false);

    const JWT = sessionStorage.getItem("token")
    if (!JWT)
        SetAuthState(prev => prev = false);
    else {
        // Make request to api, I know it should be in headers. Bite me ill fix it later
        fetch(`${apiBaseUrl}Auth/Auth?_token=${JWT}`).then(response => {
            switch (response.status) {
                case 200:
                    SetAuthState(prev => prev = true)
                    break;
                case 401:
                    SetAuthState(prev => prev = false);
                    break;
            }
        })

    }
    return [AuthState];
};