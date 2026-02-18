import { useEffect, useMemo, useState } from "react";
import {
  getBooks,
  updateAvailability
} from "../features/books/api/booksApi";
import { BookList } from "../features/books/ui/BookList";
import { BookSearch } from "../features/books/ui/BookSearch";
import { Book } from "../entities/book/model/book";

export function LibraryPage() {
  const [books, setBooks] = useState<Book[]>([]);
  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize] = useState(6);
  const [totalCount, setTotalCount] = useState(0);
  const [search, setSearch] = useState("");

  const totalPages = useMemo(() => Math.max(1, Math.ceil(totalCount / pageSize)), [
    totalCount,
    pageSize
  ]);

  const loadPage = async (page = pageNumber) => {
    try {
      const data = await getBooks(page, pageSize);
      setBooks(data.items);
      setTotalCount(data.totalCount);
      setPageNumber(data.pageNumber);
    } finally {
    }
  };

  useEffect(() => {
    if (search.trim().length > 0) {
      return;
    }
    void loadPage(1);
  }, []);

  const handleSearch = async (value: string) => {
    //TODO: Implement search book logic
    setSearch(value);
  };

  const handleToggleAvailability = async (book: Book) => {
    try {
      const updated = await updateAvailability(book.id, !book.isAvailable);
      setBooks((prev) =>
        prev.map((b) => (b.id === updated.id ? { ...b, isAvailable: updated.isAvailable } : b))
      );
    } finally {
    }
  };

  const handleDelete = async (book: Book) => {
    //TODO: Implement delete book logic
  };

  const handleAddBook = async (title: string, owner: string) => {
    //TODO: Implement create book logic
  };

  return (
    <div className="page">
      <header className="page-header">
        <div className="page-title">Library Inventory</div>
        <div className="search-row">
          <BookSearch value={search} onChange={handleSearch} />
        </div>
      </header>

      <BookList
        books={books}
        onToggleAvailability={handleToggleAvailability}
        onDelete={handleDelete}
      />

      {!search.trim() && (
        <div className="footer">
          <div>
            Page {pageNumber} of {totalPages}
          </div>
          <div className="page-controls">
            <button
              className="ghost-button"
              disabled={pageNumber <= 1}
              onClick={() => loadPage(pageNumber - 1)}
            >
              Previous
            </button>
            <button
              className="ghost-button"
              disabled={pageNumber >= totalPages}
              onClick={() => loadPage(pageNumber + 1)}
            >
              Next
            </button>
          </div>
        </div>
      )}

      <button className="add-button" onClick={() => {}}>
        Add Book
      </button>
    </div>
  );
}
