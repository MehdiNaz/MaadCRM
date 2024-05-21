export default function CategoryCarousel({
    categories
}) {
    return (
        <div className="w-full">
            {categories.map((category: Object) => {
                <div className="w-full">
                </div>
            })}
        </div>
    )
}