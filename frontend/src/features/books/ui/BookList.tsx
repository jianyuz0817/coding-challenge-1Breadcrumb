import { Book } from "../../../entities/book/model/book";

type Props = {
  books: Book[];
  onToggleAvailability: (book: Book) => void;
  onDelete: (book: Book) => void;
};

export function BookList({ books, onToggleAvailability, onDelete }: Props) {
  if (books.length === 0) {
    return <p>No books found.</p>;
  }

  return (
    <div className="list">
      <div className="card card-header">
        <span>Title</span>
        <span>Owner</span>
        <span>Status</span>
        <span>Toggle</span>
        <span>Delete</span>
      </div>
      {books.map((book) => (
        <div className="card" key={book.id}>
          <div>{book.title}</div>
          <div>{book.author}</div>
          <div>{book.isAvailable? "Available" : "Not Available"}</div>
          <label className="toggle">
            <input
              type="checkbox"
              checked={book.isAvailable}
              onChange={() => onToggleAvailability(book)}
            />
            <span>{book.isAvailable ? "Yes" : "No"}</span>
          </label>
          <button className="icon-button" onClick={() => onDelete(book)}>
            X
          </button>
        </div>
      ))}
    </div>
  );
}
