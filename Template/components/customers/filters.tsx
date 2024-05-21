// import { useCallback, useEffect, useState } from "react";
// import { IoMdClose } from "react-icons/io";
// import { usePathname, useRouter, useSearchParams } from "next/navigation"

// export default function Filters({ data }) {
//     const [filters, setFilter] = useState(data)
//     const router = useRouter()
//     const searchParams = useSearchParams()
//     const params = new URLSearchParams(searchParams)
//     const pathname = usePathname()

//     useEffect(() => {
//         setFilter(data)
//     }, [data])

//     const removeQueryString = useCallback(
//         (name: string) => {
//             const params = new URLSearchParams(searchParams)
//             params.delete(name)

//             return params.toString()
//         },
//         [searchParams]
//     )

//     return (
//         <div className="filters">
//             {filters.length > 0 && filters.map((filter, index) => {
//                 switch (filter) {
//                     case "state":
//                         return (
//                             <div key={index} className="flex items-center text-xs bg-slate-500 text-white px-2 py-1 rounded-md">
//                                 <IoMdClose
//                                     onClick={() => {
//                                         router.push(pathname + '?' + removeQueryString('state'))
//                                         setFilter(filters.filter((item) => item !== filter))
//                                     }}
//                                     className="ml-2 cursor-pointer" />
//                                 وضعیت مشتری
//                             </div>
//                         )
//                     default:
//                         return null
//                 }
//             })}
//         </div>
//     )

// }