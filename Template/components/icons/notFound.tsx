import Image from "next/image";

export default function NotFound() {
    return (
        <Image
            alt='Not Found'
            width={300}
            height={300}
            src='/icons/not-found.svg'
        />
    )
}