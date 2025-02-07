import { OrderItem } from "./order-item.model"

export interface Order {
    id: string,
    isActive: boolean,
    customerId: string,
    orderDate: number,
    status: number,
    itens: OrderItem[],
    totalAmount: number
}