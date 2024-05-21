'use client'
import Page404 from "@/components/page404";

export default function NotFound({
    error,
    reset
}: {
    error: Error;
    reset: () => void;
}) {
    return (
        <Page404 error={error} reset={reset} />
    );
}
