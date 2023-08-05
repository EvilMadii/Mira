"use client";

import { Navlinks } from "@/utils/cms"
import { NavLink } from "./Navlink"
import { ProfileNav } from "./ProfileNav"
import Link from "next/link"
import { UseAuthStore, AuthStoreTypes } from "@/stores/auth";
import { SignInButton } from "./SignInBtn";
export const Navbar = () => {
    const jwt = UseAuthStore((state: any) => state.JWT);


    return (
        <nav className="flex w-auto pb-[0.05px] border-b-SecondaryAccent border-b-2 bg-Primary text-white">
            <div className="border-r-[1px] px-8 border-SecondaryAccent border-double border-opacity-50">
                <Link href="/">
                    <h1 className="xl:text-2xl p-4 uppercase logo">Mira</h1>
                </Link>
            </div>
            <div className="ml-auto mr-0 pl-8 w-auto flex gap-4 items-center">
                <ul className="flex flex-row justify-end gap-8">
                    {Navlinks.map((item, index) => (<li className="" key={index}><NavLink href={item.href} name={item.name} /></li>))}
                </ul>
            </div>
            <div className="flex px-4 items-center justify-end">
                {!jwt ? (
                    <Link href="/login">
                        <SignInButton />
                    </Link>
                )
                    : (<Link href="/profile">
                        <ProfileNav imageUrl={""} />
                    </Link>)}

            </div>

        </nav >
    )
}

