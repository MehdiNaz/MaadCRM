'use client'
import { TableBoxType } from '@/types/customComponents';
import { Table } from '@mantine/core';

export default function TableBox({ data, columns, striped }: TableBoxType) {


    return (
        <Table
            striped={striped}
        >
            <thead>
                <tr>
                    {columns.map((column, index) => (
                        <th key={index}>{column.label}</th>
                    ))}
                </tr>
            </thead>
            <tbody>
                {data.map((element, index) => (
                    <tr key={index}>
                        {columns.map((column, index) => (
                            <td key={index}>{element[column.id]}</td>
                        ))}
                    </tr>
                ))}
            </tbody>
        </Table>
    );
}