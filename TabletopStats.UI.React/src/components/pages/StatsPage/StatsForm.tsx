import { useForm, SubmitHandler } from "react-hook-form";
import { SessionLog } from "../../../models/SessionLog";
import Input from "../../common/Input";
import Select, { Item } from "../../common/Select";
import Toggle from "../../common/Toggle";
import Button from "../../common/Button";
import dictionaryService from "../../../services/dictionaryService";
import { keepPreviousData, useQuery } from "@tanstack/react-query";
import { RpgSystem } from "../../../models/RpgSystem";

const StatsForm = () => {
  const { isPending, isError, error, data, isFetching } = useQuery({
    queryKey: ["fetchRpgSystems"],
    queryFn: () => dictionaryService.fetchRpgSystems(""),
    placeholderData: keepPreviousData,
  });

  const {
    register,
    handleSubmit,
    getValues,
    watch,
    control,
    formState: { errors,  },
  } = useForm<SessionLog>({
    defaultValues: {
      sessionName: "",
    },
  });
  const onSubmit = handleSubmit((data) => console.log(data));

  return (
    <div className="grid gap-y-4">
      <Input
        label={"Session Name"}
        {...register("sessionName")}
        control={control}
      />
      <Select
        label={"Rpg System"}
        options={
          data?.data.map<Item>((x) => ({
            label: x.name,
            value: x.code,
          })) ?? []
        }
      />
      <Toggle labelLeft={"One-shot"} labelRight={"Adventure"} />
      <Select label={"Adventures"} options={[]} />
      {/* TODO: fullfill */}
      <Select label={"Game Master"} options={[]} />
      <Select label={"Players"} options={[]} />
      <Button label={"Send session log"} onClick={onSubmit} />
    </div>
  );
};

export default StatsForm;
