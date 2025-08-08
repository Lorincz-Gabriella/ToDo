import { create } from "zustand"

export const useUIStore = create((set) => ({
    
    isAddToDoFormVisible: false,
    toggleToDoForm: () =>
        set((state) => ({
            isAddToDoFormVisible: !state.isAddToDoFormVisible
        })),

}))