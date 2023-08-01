import { create } from "zustand";

export interface AuthStoreTypes {
    JWT: string
    setJWT: (jwt: string) => void
    removeJWT: () => void
}

export const UseAuthStore = create(
    (set) => ({
        JWT: "",
        setJWT: (jwt: string) => set(() => ({ JWT: jwt })),
        removeJWT: () => set(() => ({ JWT: "" }))
    })
)

