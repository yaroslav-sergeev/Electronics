import { Guid } from "guid-typescript";

export interface Product {
    id: Guid;
    name: string;
    brand: string;
    category: string;
    color: string;
    dimention: string;
    weight: any;
    os: string;
    discount?: any;
    imageData?: string;
    imagePath?: string;
}
