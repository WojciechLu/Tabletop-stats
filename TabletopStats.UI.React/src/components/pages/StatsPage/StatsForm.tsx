import { useForm, SubmitHandler, Controller } from "react-hook-form";
import { SessionLog } from "../../../models/SessionLog";
import Input from "../../common/Input";
import Select, { Item } from "../../common/Modal/Select/Select";
import Toggle from "../../common/Toggle";
import Button from "../../common/Button";
import dictionaryService from "../../../services/dictionaryService";
import { keepPreviousData, useQuery } from "@tanstack/react-query";
import { RpgSystem } from "../../../models/RpgSystem";
import { useState } from "react";

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
  const [isAdventure, setIsAdventure] = useState<boolean>(false);

  return (
    <div className="grid gap-y-2">
      <Input
        label={"Session Name"}
        {...register("sessionName")}
        control={control}
      />
      
      <Controller
        name="rpgSystem"
        control={control}
        render={({ field: { onChange, onBlur, value, ref } }) => {
          const onChangeItemToRpgSystem = (item: Item) => {
            const rpgSystem: RpgSystem = {
              code: item.value,
              name: item.label
            }
            onChange(rpgSystem)
          }
          return (
          <Select
            label={"Rpg System"}
            options={
              data?.data.map<Item>((x) => ({
                label: x.name,
                value: x.code,
              })) ?? []
            }
            onChange={onChangeItemToRpgSystem}
          />)
        }
      }
      />
      {/* <Select
        label={"Rpg System"}
        options={
          data?.data.map<Item>((x) => ({
            label: x.name,
            value: x.code,
          })) ?? []
        }
        {...register("rpgSystem")}
      /> */}
      <Toggle labelLeft={"One-shot"} labelRight={"Adventure"} onChange={() => setIsAdventure(prev => !prev)} checked={isAdventure}/>
      {isAdventure && <Select label={"Adventures"} options={[]} />}
      
      {/* TODO: fullfill */}
      <Select label={"Game Master"} options={[]} />
      <Select label={"Players"} options={[]} />
      <Button label={"Send session log"} onClick={onSubmit} />
    </div>
  );
};

export default StatsForm;
