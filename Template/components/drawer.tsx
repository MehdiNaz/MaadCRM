import { Drawer as DR, DrawerProps } from "@mantine/core"
export default function Drawer({ ...props }: DrawerProps) {
    return (
        <DR {...props}>
            {props.children}
        </DR>
    )
}