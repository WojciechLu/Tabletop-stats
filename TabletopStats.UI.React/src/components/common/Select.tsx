import { useState } from "react";

export interface Item {
  value: string;
  label: string;
}

interface SelectProps {
  label: string;
  options: Item[];
}

const Select = ({ label, options }: SelectProps) => {
  const [selected, setSelected] = useState<string[]>([]);
  const [open, setOpen] = useState(false);
  const [search, setSearch] = useState("");

  const toggleItem = (value: string) => {
    setSelected(prev => prev.includes(value) ? prev.filter(i => i !== value) : [...prev, value]);
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
            <span>{selected.length === 0 ? label : `${label}: ${selected.length}`}</span>
            <span>▼</span>
          </button>

          {open && (
            <div className="absolute z-10 w-full mt-2 rounded bg-white border border-grey-500">
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
                    onClick={() => toggleItem(item.value)}
                    className={`flex items-center gap-2 px-4 py-2 cursor-pointer ${selected.includes(item.value) ? 'bg-grey-200' : ''}`}
                  >
                    <input type="checkbox" readOnly checked={selected.includes(item.value)} className="w-4 h-4" />
                    <span>{item.label}</span>
                  </div>
                ))}
              </div>
            </div>
          )}
        </div>

        <div className="mt-4 flex flex-wrap gap-2">
          {selected.map(value => {
            const item = options.find(i => i.value === value);
            if (!item) return null;
            return (
              <span key={value} className="inline-flex items-center px-3 py-1 rounded-full bg-grey-100 text-grey-800">
                {item.label}
                <button onClick={() => toggleItem(value)} className="ml-2">×</button>
              </span>
            );
          })}
        </div>
      </div>
    </div>
  );
};

export default Select;
