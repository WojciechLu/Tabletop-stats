import { createFileRoute } from '@tanstack/react-router'
import StatsPage from '../components/pages/StatsPage/StatsPage'

export const Route = createFileRoute('/')({
  component: StatsPage,
})