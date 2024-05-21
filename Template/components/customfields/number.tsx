import InputNumber from "../numberInput";

export default function NumberBox({ Label }, ...props) {
    return (
        <InputNumber
            placeholder={Label}
            {...props}
        />
    )
}