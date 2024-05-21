import './globals.css'
import Provider from "./provider"
import { cookies } from 'next/headers'
import axios from 'utils/axios'
import { redirect } from 'next/navigation'
import NextTopLoader from 'nextjs-toploader';
import { Metadata } from 'next'


export const metadata: Metadata = {
  title: 'نرم افزار مدیریت مشتریان ماد',

}
export default function RootLayout({ children }) {

  const nextCookies = cookies()
  const token = nextCookies.get('token')

  if (token) {
    axios.defaults.headers.common['Authorization'] = `Bearer ${token.value}`
  }

  return (
    <html dir='rtl' lang="en">
      <body>
        <NextTopLoader
          color="#fff"
          showSpinner={false}
        />
        <Provider>{children}</Provider>
      </body>
    </html>
  )
}

