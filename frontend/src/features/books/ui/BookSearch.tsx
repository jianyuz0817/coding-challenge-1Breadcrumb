type Props = {
  value: string;
  onChange: (value: string) => void;
};

export function BookSearch({ value, onChange }: Props) {
  return (
    <input
      className="search-input"
      placeholder="Search by title..."
      value={value}
      onChange={(event) => onChange(event.target.value)}
    />
  );
}
