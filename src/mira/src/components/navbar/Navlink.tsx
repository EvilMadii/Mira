import Link from "next/link"


type NavLinkProps = {
    name: string;
    href: string;
}


export const NavLink = (props: NavLinkProps) => {
    return (
        <Link href={props.href}>
            {props.name.toUpperCase()}
        </Link>
    )
}