import { useState } from "react";

export default function ImageRadio({ options, name }:
    { options: Array<{ id: string, label: string, image: string }>, name: string }
) {

    const [selected, setSelected] = useState<string>(options[0].id)


    return (
        <div className="w-full grid grid-cols-4">
            {options.map((option: any, index: number) => (
                <div key={index} className="flex flex-col">
                    <div className="flex items-center">
                        <input type="radio" name={name} id={option.id} className="w-4 h-4" />
                        <label htmlFor={option.id} className="mr-2">{option.label}</label>
                    </div>
                    {/* <img src={option.image} alt={option.label} className="w-10 h-10 mt-5" /> */}
                </div>
            ))}
        </div>
    )
}