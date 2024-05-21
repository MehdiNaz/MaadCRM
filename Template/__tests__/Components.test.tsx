import { render, screen } from '@testing-library/react'
import Components from 'app/components/page'

it('should have text', () => {
    render(<Components />)

    const element = screen.getByText('Hello Hadi')

    expect(element).toBeInTheDocument()
})