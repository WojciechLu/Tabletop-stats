import { useState } from "react";

interface ToggleProps {
  labelLeft: string;
  labelRight: string;
}

const Toggle = ({ labelLeft, labelRight }: ToggleProps) => {
  const [checked, setChecked] = useState<boolean>(false);

  return (
    <div>
      <label
        htmlFor="Toggle"
        className="inline-flex items-center space-x-4 cursor-pointer text-gray-800 mb-2 text-sm font-medium text-heading"
      >
        <span>{labelLeft}</span>
        <span className="relative">
          <input id="Toggle" type="checkbox" className="hidden peer" />
          <div className="w-10 h-6 rounded-full shadow-inner bg-gray-600 peer-checked:bg-blue-600"></div>
          <div className="absolute inset-y-0 left-0 w-4 h-4 m-1 rounded-full shadow peer-checked:right-0 peer-checked:left-auto bg-gray-100"></div>
        </span>
        <span>{labelRight}</span>
      </label>
    </div>
  );
};

export default Toggle;
