'use client'

import { CacheProvider } from '@emotion/react'
import { MantineProvider } from '@mantine/core'
import { useServerInsertedHTML } from 'next/navigation'
import rtlPlugin from 'stylis-plugin-rtl'
import { Notifications } from '@mantine/notifications'
import createCache from '@emotion/cache'
import { ModalsProvider } from '@mantine/modals';
import { Provider as ReduxProvider } from 'react-redux'
import { store } from '../store/store'

export default function Provider({ children }: { children: React.ReactNode }) {

    const cache = createCache({ key: 'mantine-rtl', stylisPlugins: [rtlPlugin] })
    cache.compat = true


    useServerInsertedHTML(() => {
        return (
            <style
                data-emotion={`${cache.key} ${Object.keys(cache.inserted).join(" ")}`}
                dangerouslySetInnerHTML={{
                    __html: Object.values(cache.inserted).join(" "),
                }}
            />
        );
    });


    return (
        <CacheProvider value={cache}>
            <ReduxProvider store={store}>
                <MantineProvider emotionCache={cache} theme={{ dir: 'rtl' }}>
                    <ModalsProvider>
                        <Notifications position='top-left' />
                        {children}
                    </ModalsProvider>
                </MantineProvider>
            </ReduxProvider>
        </CacheProvider>
    );
}