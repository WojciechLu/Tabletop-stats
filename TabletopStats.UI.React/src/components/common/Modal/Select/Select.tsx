import { useState } from "react";
import MultiSelect from "./MultiSelect";
import SingleSelect from "./SingleSelect";

export interface Item {
  value: string;
  label: string;
}

interface SelectProps {
  label: string;
  options: Item[];
  multi?: boolean;
  onChange: (...event: any[]) => void;
}

const Select = ({ label, options, multi, onChange }: SelectProps) => {
  return multi ? <MultiSelect label={label} options={options} onChange={onChange} /> : <SingleSelect label={label} options={options} onChange={onChange}/> ;
};

export default Select;
