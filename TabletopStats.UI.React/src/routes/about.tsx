import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/about')({
  component: About,
})

function About() {
  return (
    <div className="text-3xl font-bold underline">
      Hello world!
    </div>
  )
}