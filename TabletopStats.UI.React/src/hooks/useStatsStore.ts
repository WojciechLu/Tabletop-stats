import { create } from 'zustand'

interface StatsState {
  count: number;
  increment: () => void;
  decrement: () => void;
}

export const useCounterStore = create<StatsState>((set) => ({
  count: 0,
  increment: () => set((state) => ({ count: state.count + 1 })),
  decrement: () => set((state) => ({ count: state.count - 1 })),
}));
