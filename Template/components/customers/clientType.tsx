import { ClientProfileType } from '../../types/clients'

export default function clientType({ type }: ClientProfileType) {

    const types = {
        balghav: 'بالقوه',
        peygiri: 'درحال پیگیری',
        razi: 'راضی',
        narazi: 'ناراضی',
        vafadar: 'وفادار',
        belfel: 'بالفعل'
    }

    const typeStyle = {
        razi: 'border-green-700 text-green-700',
        narazi: 'border-red-800 text-red-800',
    }

    return (
        <div
            className={`user-type-box border rounded-full w-28 h-28 flex justify-center items-center`
                + ` ${typeStyle[type]}`}
        >
            <span>
                {types[type]}
            </span>
        </div >
    )
}