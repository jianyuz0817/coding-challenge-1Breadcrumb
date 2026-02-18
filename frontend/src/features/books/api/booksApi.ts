import { Book } from "../../../entities/book/model/book";
import { apiBaseUrl } from "../../../shared/config/api";

export type PagedBooks = {
  items: Book[];
  pageNumber: number;
  pageSize: number;
  totalCount: number;
};

const baseUrl = apiBaseUrl;

export async function getBooks(pageNumber: number, pageSize: number): Promise<PagedBooks> {
  const response = await fetch(
    `${baseUrl}/books?pageNumber=${pageNumber}&pageSize=${pageSize}`
  );
  if (!response.ok) {
    throw new Error("Failed to load books.");
  }
  return response.json();
}

export async function updateAvailability(id: string, isAvailable: boolean): Promise<Book> {
  const response = await fetch(`${baseUrl}/books/${id}/availability`, {
    method: "PATCH",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ isAvailable })
  });
  if (!response.ok) {
    throw new Error("Failed to update availability.");
  }
  return response.json();
}

