interface Item {
  value: string;
  label: string;
}

interface SelectProps {
  label: string;
  options: Item[];
}

const Select = ({ label, options }: SelectProps) => {
  return (
    <div>
      <label
        htmlFor="countries"
        className="block mb-1 text-sm font-medium text-heading"
      >
        {label}
      </label>
      <select
        id="countries"
        className="block w-full px-3 py-2 bg-neutral-secondary-medium border border-default-medium text-heading text-sm rounded-base focus:ring-brand focus:border-brand shadow-xs placeholder:text-body"
      >
        {options.map((item) => (
          <option value={item.value}>{item.label}</option>
        ))}
      </select>
    </div>
  );
};

export default Select;
