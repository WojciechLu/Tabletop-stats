import {
  useForm,
  useController,
  UseControllerProps,
  FieldValues,
  Controller,
} from "react-hook-form";

interface InputProps<T extends FieldValues> extends UseControllerProps<T> {
  label: string;
}

const Input = <T extends FieldValues>({
  label,
  name,
  control,
}: InputProps<T>) => {
  return (
    <Controller
      render={({ field }) => (
        <div>
          <label
            htmlFor="visitors"
            className="block mb-1 text-sm font-medium text-heading"
          >
            {label}
          </label>
          <input
          {...field}
            type="text"
            id="visitors"
            className="bg-neutral-secondary-medium border border-default-medium text-heading text-sm rounded-base focus:ring-brand focus:border-brand block w-full px-3 py-2 shadow-xs placeholder:text-body"
            placeholder=""
            value={field.value}
            onChange={field.onChange}
            required
          />
        </div>
      )}
      name={name}
      control={control}
    />
  );
};

export default Input;
