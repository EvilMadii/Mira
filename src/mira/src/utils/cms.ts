interface INavlinks {
    name: string;
    href: string;
}
export const Navlinks: INavlinks[] = [
    {
        name: "dashboard",
        href: "/dashboard"
    },
    {
        name: "projects",
        href: "/projects"
    },
    {
        name: "tasks",
        href: "/tasks"
    },
    {
        name: "notes",
        href: "/notes"
    }
]

interface IFooterLinks {
    name: string;
    href: string;
}
export const FooterLinks: IFooterLinks[] = [
    {
        name: "about",
        href: "/about"
    },
    {
        name: "Privacy Policy",
        href: "/Privacy"
    },
    {
        name: "support",
        href: "/Support"
    },
    {
        name: "FAQS",
        href: "/faqs"
    }
]
