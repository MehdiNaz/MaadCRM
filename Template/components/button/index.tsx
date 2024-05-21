import { Button as BTN } from '@mantine/core'

export default function Button({ ...props }) {

    props.className = '!font-medium ' + props.className
    if (!props.color)
        props.className += ' !bg-primary'

    return (
        <BTN
            {...props}
        >
            {props.children}
        </BTN>
    )
}