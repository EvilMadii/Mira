import { UseAuthStore, AuthStoreTypes } from "@/stores/auth"



export const UseAuth = () => {
    const JWT = UseAuthStore((state: any) => {
        if (state.JWT)
            return state.JWT
        else
            throw new Error("cannot load state");
    });
}