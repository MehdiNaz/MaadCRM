'use client'

import { Box, Center, SegmentedControl as SegmentedControlComponent } from '@mantine/core'
import { useState } from 'react'

export default function SegmentedControl({
    onChange,
}) {

    const [active, setActive] = useState<string>('done')
    return (
        <>
            <SegmentedControlComponent
                onChange={(value) => {
                    setActive(value)
                    onChange(value)
                }}
                style={{
                    width: '100%'
                }}
                className="SegmentedControlComponent-box"
                classNames={{
                    root: 'w-full',
                    controlActive: 'bg-primary'
                }}
                data={[
                    {
                        value: '1',
                        label: (
                            <Center>
                                <Box
                                    className={active === 'done' ? 'text-white' : ''}
                                    ml={10}>انجام شده</Box>
                            </Center>
                        )
                    },
                    {
                        value: '2',
                        label: (
                            <div style={{ width: '100%' }}>
                                <Center>
                                    <Box
                                        className={active === 'future' ? 'text-white' : ''}
                                        ml={10}>پیگیری آتی</Box>
                                </Center>
                            </div>
                        )
                    }
                ]}
            />
        </>
    )

}