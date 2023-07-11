import { FooterLinks } from "@/utils/cms"
import { FooterLink } from "./FooterLink"
export const Footer = () => {
    return (
        <footer className="flex bg-Primary p-4 border-t-2 border-t-SecondaryAccent text-white">
            <div className="">
                <h1 className="logo px-8 text-lg justify-center items-center">MIRA</h1>
            </div>
            {/* footer links */}
            <div className="flex ml-auto pr-4">
                <ul className="flex items-center  justify-center gap-8">
                    {FooterLinks.map((item, key) => (<li className="" key={key}><FooterLink href={item.href} name={item.name} /></li>))}
                </ul>
            </div>
        </footer>
    )
}