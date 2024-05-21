import TextInput from "../textInput";

export default function TextBox({ Label, IsRequired }) {
    return (
        <TextInput
            label='عنوان فیلد'
            placeholder='مثال: شماره تلفن'
        />
    )
}