import Link from "next/link";

type FooterLinkProps = {
    name: string;
    href: string
}

export const FooterLink = (props: FooterLinkProps) => (<Link href={props.href}>{props.name.toUpperCase()}</Link>)