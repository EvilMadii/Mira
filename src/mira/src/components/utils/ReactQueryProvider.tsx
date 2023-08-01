"use client";

import { QueryClientProvider, QueryClient } from '@tanstack/react-query'
interface ReactQueryProviderProps {
    children: React.ReactNode;
}
const _queryClient = new QueryClient();
export const ReactQueryProvider: React.FC<ReactQueryProviderProps> = ({ children }) => (<QueryClientProvider client={_queryClient}>{children}</QueryClientProvider>)