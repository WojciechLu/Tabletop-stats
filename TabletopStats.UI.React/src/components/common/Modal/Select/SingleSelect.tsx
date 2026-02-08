import { useState } from "react";

export interface Item {
  value: string;
  label: string;
}

interface SelectProps {
  label: string;
  options: Item[];
  onChange: (...event: any[]) => void;
}

const SingleSelect = ({ label, options, onChange }: SelectProps) => {
  const [selected, setSelected] = useState<Item | null>();
  const [open, setOpen] = useState(false);
  const [search, setSearch] = useState("");

  const toggleItem = (value: Item) => {
    setSelected(value);
    onChange(value)
    setOpen(false)
  };

  const filteredOptions = options.filter(item => item.label.toLowerCase().includes(search.toLowerCase()));

  return (
    <div>
      <div className="max-w-6xl mx-auto">
        <div className="relative">
          <button
            type="button"
            onClick={() => setOpen(prev => !prev)}
            className="inline-flex justify-between w-full bg-gray-50 rounded px-2 py-2 text-base text-stone-500 border border-stone-300"
          >
            <span>{selected ? selected.label : label }</span>
            <span>▼</span>
          </button>

          {open && (
            <div className="absolute z-10 w-full rounded bg-white border border-grey-500">
              <input
                id="select"
                type="text"
                value={search}
                onChange={e => setSearch(e.target.value)}
                placeholder={`Search ${label.toLowerCase()}`}
                className="w-full px-4 py-2 border-b"
              />
              <div className="max-h-60 overflow-y-auto">
                {filteredOptions.map(item => (
                  <div
                    key={item.value}
                    onClick={() => toggleItem(item)}
                    className={`flex items-center gap-2 px-4 py-2 cursor-pointer ${selected?.value.includes(item.value) ? 'bg-grey-200' : ''}`}
                  >
                    <span>{item.label}</span>
                  </div>
                ))}
              </div>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default SingleSelect;
