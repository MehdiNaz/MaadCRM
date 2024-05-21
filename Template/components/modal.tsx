import { MaadModalType } from "@/types/customComponents";
import { LoadingOverlay, Modal as MantineModal } from "@mantine/core";
import { randomId } from "@mantine/hooks";

export default function Modal(
    { classNames, loading, ...props }: MaadModalType
) {

    let classNamesList = {
        content: '!z-10',
        header: '!z-0 border-b-4 border-primary',
    }

    if (classNames) {
        classNamesList = {
            ...classNamesList,
            ...classNames
        }
    }

    const id = 'modalBox-' + randomId()

    return (
        <MantineModal
            classNames={classNamesList}
            {...props}
        >
            <LoadingOverlay visible={loading} />
            <div className="px-4 py-4 rounded-md mt-4">
                {props.children}
            </div>
        </MantineModal >
    )
}