using NGVSCAN.CORE.Entities;
using NGVSCAN.CORE.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace NGVSCAN.DAL.Context
{
    public class NGVSCANInitializer : CreateDatabaseIfNotExists<NGVSCANContext>
    {
        protected override void Seed(NGVSCANContext context)
        {
            IList<FloutecParamsTypes> paramsTypes = new List<FloutecParamsTypes>();

            paramsTypes.Add(new FloutecParamsTypes() { Code = 0, Param = "Д", Description = "Давление" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 1, Param = "Т", Description = "Температура" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 2, Param = "ПД", Description = "Перепад давления" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 3, Param = "ПДН", Description = "Перепад давления низкий" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 4, Param = "ПДВ", Description = "Перепад давления высокий" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 7, Param = "П", Description = "Плотность" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 39, Param = "Р", Description = "Расход" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 40, Param = "С", Description = "Счётчик" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 42, Param = "Р,Т,П", Description = "Расход, температура, плотность" });

            foreach (FloutecParamsTypes param in paramsTypes)
            {
                context.FloutecParamsTypes.Add(param);
            }

            IList<FloutecAlarmsTypes> alarmsTypes = new List<FloutecAlarmsTypes>();

            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 0, Description = "Опрос в норме, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 128, Description = "Опрос не в норме, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 1, Description = "Конец обслуживания канала" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 129, Description = "Начало обслуживания канала" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 2, Description = "Перепад давления выше значения отсечки" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 130, Description = "Перепад давления ниже или равен отсечке" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 3, Description = "Конец замены измерения константой" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 4, Description = "Конец замены измерения несанкционированной константой" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 132, Description = "Начало замены измерения несанкционированной константой" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 131, Description = "Начало замены измерения константой" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 5, Description = "Напряжение питания стало нормальным" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 133, Description = "Напряжение питания ниже допуска" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 6, Description = "Перепад давления стал ниже верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 134, Description = "Перепад давления стал выше верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 7, Description = "Первое включение вычислителя после конфигурирования, подано напряжение питания вычислителя" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 135, Description = "Снято напряжение питания вычислителя" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 138, Description = "Данные часов/календаря недостоверны" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 11, Description = "Отношение ПД/Д стало нормальным" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 139, Description = "Отношение ПД/Д не в норме" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 12, Description = "Re стало нормальным" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 140, Description = "Re вышло за допускаемые пределы" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 13, Description = "Конец деления на 0, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 141, Description = "Начало деления на 0, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 14, Description = "Конец работы от аккумулятора" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 142, Description = "Начало работы от аккумулятора" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 15, Description = "Температура стала выше -40 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 143, Description = "Температура стала ниже -40 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 16, Description = "Температура стала ниже 80 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 144, Description = "Температура стала выше 80 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 145, Description = "Время вычислителя и ПК отличаются более чем на 10 минут" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 18, Description = "Скорость ротора счётчика стала нормальной" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 146, Description = "Скорость ротора счётчика стала выше допустимой" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 19, Description = "Условия для расчёта F стали нормальными" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 147, Description = "Условия для расчёта F стали ненормальными" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 20, Description = "Конец использования нижнего ПД" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 148, Description = "Начало использования нижнего ПД" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 21, Description = "Изменена калибровка канала" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 22, Description = "ПДВ ниже верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 150, Description = "ПДВ выше верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 23, Description = "Давление стало ниже верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 151, Description = "Давление стало выше верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 24, Description = "Температура стала выше -25 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 152, Description = "Температура стала ниже -25 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 25, Description = "Абсолютное давление стало ниже" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 153, Description = "Абсолютное давление стало выше" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 26, Description = "Температура стала выше -30 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 154, Description = "Температура стала ниже -30 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 27, Description = "Коэффициент Ксж в норме, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 155, Description = "Коэффициент Ксж меньше 0, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 28, Description = "Абсолютное давление выше минимального атмосферного давления, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 156, Description = "Абсолютное давление ниже минимального атмосферного давления, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 29, Description = "Вязкость в норме, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 157, Description = "Вязкость не в норме, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 30, Description = "Значение не NAN, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 158, Description = "Значение NAN, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 31, Description = "Значение меньше максимально допустимого, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 159, Description = "Значение выше максимально допустимого, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 32, Description = "Значение выше минимально допустимого, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 160, Description = "Значение ниже минимально допустимого, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 33, Description = "Конец обратного потока, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 161, Description = "Начало обратного потока, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 34, Description = "Единицы измерения в норме, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 162, Description = "Единицы измерения не в норме, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 149, Description = "Ошибка опроса датчика" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 39, Description = "ПДН стал ниже верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 167, Description = "ПДН стал выше верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 40, Description = "Подано напряжение питания" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 168, Description = "Снято напряжение питания" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 41, Description = "Конфигурирование вычислителя" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 42, Description = "Абсолютное давление стало больше или равно" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 170, Description = "Абсолютное давление стало ниже" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 43, Description = "Температура стала ниже 66.85 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 171, Description = "Температура стала выше 66.85 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 44, Description = "Температура стала выше -23.15 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 172, Description = "Температура стала ниже -23.15 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 35, Description = "Установка нуля канала" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 36, Description = "Абсолютное давление стало ниже 100 кгс/см2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 164, Description = "Абсолютное давление стало выше 100 кгс/см2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 37, Description = "Конец режима 'заморозки'" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 165, Description = "Начало режима 'заморозки'" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 38, Description = "Конец использования НСХП канала" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 166, Description = "Начало использования НСХП канала" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 45, Description = "Расчёт плотности в норме, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 173, Description = "Расчёт плотности не в норме, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 50, Description = "Температура сенсора SMV стала нормальной" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 178, Description = "Температура сенсора SMV стала выше нормы" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 51, Description = "Температура стала ниже 40 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 179, Description = "Температура стала выше 40 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 52, Description = "Температура стала выше -10 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 180, Description = "Температура стала ниже -10 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 53, Description = "Абсолютное давление стало выше 11 кгс/см2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 181, Description = "Абсолютное давление стало ниже 11 кгс/см2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 54, Description = "Абсолютное давление стало ниже 26 кгс/см2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 182, Description = "Абсолютное давление стало выше 26 кгс/см2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 55, Description = "Значение стало выше НМП" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 183, Description = "Значение стало ниже НМП" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 56, Description = "Значение стало ниже ВМП" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 184, Description = "Значение стало выше ВМП" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 57, Description = "Значение стало выше НПИ" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 185, Description = "Значение стало ниже НПИ" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 58, Description = "Значение стало ниже НПИ" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 186, Description = "Значение стало выше НПИ" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 8, Description = "Расчёт по ГОСТ 8.586 стал возможным" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 136, Description = "Расчёт по ГОСТ 8.586 стал невозможным" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 9, Description = "Запись во FLASH-память не выполнена" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 137, Description = "Запись в буфер FLASH-памяти не выполнена" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 46, Description = "Аккумулятор КВВ в норме" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 174, Description = "Аккумулятор КВВ разряжен" });

            IList<Field> fields = new List<Field>();

            fields.Add(new Field() { DateCreated = DateTime.Now, DateModified = DateTime.Now, IsDeleted = false, Id = 1, Name = "SEM-SRV", Description = "УКПГ Семиренки" });
            fields.Add(new Field() { DateCreated = DateTime.Now, DateModified = DateTime.Now, IsDeleted = false, Id = 2, Name = "OLEF-SRV", Description = "УППГ Олефировка" });
            fields.Add(new Field() { DateCreated = DateTime.Now, DateModified = DateTime.Now, IsDeleted = false, Id = 2, Name = "MACH-SRV", Description = "УПГ Мачухи" });

            foreach (Field field in fields)
            {
                context.Fields.Add(field);
            }

            base.Seed(context);
        }
    }
}
