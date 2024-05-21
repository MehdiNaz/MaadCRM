'use client';

import Image from "next/image";
import Link from "next/link";
import Button from "./button";
import Head from "next/head";

export default function Page404({
    error,
    reset,
}: {
    error: Error;
    reset: () => void;
}) {
    return (
        <html>
            <Head>
                <title>چیزی پیدا نشد</title>
            </Head>
            <body className="bg-[#f5f5f5] flex justify-center items-center min-h-screen flex-col">
                <Image src='/icons/404.svg' width={500} height={500} alt="not found" />
                <h1 className="text-2xl mt-4 mb-8 font-bold">چیزی پیدا نشد</h1>
                <Link href='/customers'>
                    <Button className="text-xl">
                        بازگشت
                    </Button>
                </Link>
            </body>
        </html>
    );
}
