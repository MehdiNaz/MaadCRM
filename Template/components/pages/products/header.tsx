import Button from "@/components/button";
import Search from "@/components/search";
import SearchInput from "@/components/searchInput";
import Link from "next/link";
import { useRouter } from "next/navigation";

export default function ProductsHeader({
    newCategory
}) {

    const router = useRouter()

    function submitSearch() {

    }

    return (
        <>
            <div className="w-full flex justify-between">
                <div className="mr-auto">
                    <Button
                        className='ml-2'
                        onClick={() => router.push('/products/new')}
                    >
                        کالا/خدمات جدید
                    </Button>
                    <Button
                        onClick={() => newCategory()}
                    >
                        افزودن دسته بندی
                    </Button>
                    <Link href='/products/categories'>
                        <Button
                            className='mr-2'
                        >
                            لیست دسته بندی ها
                        </Button>
                    </Link>
                </div>
            </div>
        </>
    )
}