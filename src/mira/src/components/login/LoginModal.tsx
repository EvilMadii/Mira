"use client";
import { FormEvent } from "react"

export const LoginModal: React.FC = () => {
    const handleSubmit = function (e: FormEvent<HTMLFormElement>) {
        e.preventDefault();
    }

    return (
        <form onSubmit={(e) => handleSubmit(e)}>
            <h1 >login</h1>

        </form>
    )
}