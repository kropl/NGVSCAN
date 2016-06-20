using NGVSCAN.CORE.Entities;
using NGVSCAN.CORE.Entities.Floutecs.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using NGVSCAN.CORE.Entities.ROC809s.Common;

namespace NGVSCAN.DAL.Context
{
    /// <summary>
    /// Инициализация базы данных при создании
    /// </summary>
    public class NGVSCANInitializer : CreateDatabaseIfNotExists<NGVSCANContext>
    {
        protected override void Seed(NGVSCANContext context)
        {
            #region Инициализация типов параметров для вычислителей ФЛОУТЭК

            List<FloutecParamsTypes> paramsTypes = new List<FloutecParamsTypes>();

            paramsTypes.Add(new FloutecParamsTypes() { Code = 0, Param = "Д", Description = "Давление" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 1, Param = "Т", Description = "Температура" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 2, Param = "ПД", Description = "Перепад давления" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 3, Param = "ПДН", Description = "Перепад давления низкий" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 4, Param = "ПДВ", Description = "Перепад давления высокий" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 5, Param = "Пимп", Description = "Период импульсов от плотномера" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 7, Param = "П", Description = "Плотность" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 8, Param = "Пимп,Т", Description = "Период импульсов от плотномера, температура среды в плотномере" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 11, Param = "ПД,Д", Description = "Перепад давления, давление" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 15, Param = "ПД,Д,Т", Description = "Перепад давления, давление, температура" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 39, Param = "Р", Description = "Расход" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 40, Param = "С", Description = "Счётчик" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 42, Param = "Р,Т,П", Description = "Расход, температура, плотность" });

            paramsTypes.ForEach((p) => { context.FloutecParamsTypes.Add(p); });

            #endregion

            #region Инициализация типов аварий для вычислителей ФЛОУТЭК

            List<FloutecAlarmsTypes> alarmsTypes = new List<FloutecAlarmsTypes>();

            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 0, Description = "Опрос в норме, конец замены предыдущим значением", Description_45 = "Опрос в норме, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 128, Description = "Опрос не в норме, начало замены предыдущим значением", Description_45 = "Опрос не в норме, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 1, Description = "Конец обслуживания канала", Description_45 = "Конец формирования НСХП канала" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 129, Description = "Начало обслуживания канала", Description_45 = "Начало формирования НСХП канала" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 2, Description = "Перепад давления выше значения отсечки", Description_45 = "Перепад давления выше значения отсечки" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 130, Description = "Перепад давления ниже или равен отсечке", Description_45 = "Перепад давления ниже или равен отсечке" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 3, Description = "Конец замены измерения константой", Description_45 = "Конец замены измерения константой" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 4, Description = "Конец замены измерения несанкционированной константой", Description_45 = "Конец замены измерения несанкционированной константой" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 132, Description = "Начало замены измерения несанкционированной константой", Description_45 = "Начало замены измерения несанкционированной константой" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 131, Description = "Начало замены измерения константой", Description_45 = "Начало замены измерения константой" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 5, Description = "Напряжение питания стало нормальным", Description_45 = "Напряжение питания стало нормальным" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 133, Description = "Напряжение питания ниже допуска", Description_45 = "Напряжение питания ниже допуска" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 6, Description = "Перепад давления стал ниже верхнего предела измерений", Description_45 = "Перепад давления стал ниже верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 134, Description = "Перепад давления стал выше верхнего предела измерений", Description_45 = "Перепад давления стал выше верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 7, Description = "Первое включение вычислителя после конфигурирования, подано напряжение питания вычислителя", Description_45 = "Первое включение вычислителя после конфигурирования, подано напряжение питания вычислителя" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 135, Description = "Снято напряжение питания вычислителя", Description_45 = "Снято напряжение питания вычислителя" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 138, Description = "Данные часов/календаря недостоверны", Description_45 = "Данные часов/календаря недостоверны" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 11, Description = "Отношение ПД/Д стало нормальным", Description_45 = "Отношение ПД/Д стало нормальным" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 139, Description = "Отношение ПД/Д не в норме", Description_45 = "Отношение ПД/Д не в норме" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 12, Description = "Re стало нормальным", Description_45 = "Re стало нормальным" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 140, Description = "Re вышло за допускаемые пределы", Description_45 = "Re вышло за допускаемые пределы" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 13, Description = "Конец деления на 0, конец замены предыдущим значением", Description_45 = "Конец деления на 0, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 141, Description = "Начало деления на 0, начало замены предыдущим значением", Description_45 = "Начало деления на 0, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 14, Description = "Конец работы от аккумулятора", Description_45 = "Конец работы от аккумулятора" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 142, Description = "Начало работы от аккумулятора", Description_45 = "Начало работы от аккумулятора" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 15, Description = "Температура стала выше -40 °С", Description_45 = "Температура стала выше -40 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 143, Description = "Температура стала ниже -40 °С", Description_45 = "Температура стала ниже -40 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 16, Description = "Температура стала ниже 80 °С", Description_45 = "Температура стала ниже 80 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 144, Description = "Температура стала выше 80 °С", Description_45 = "Температура стала выше 80 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 145, Description = "Время вычислителя и ПК отличаются более чем на 10 минут", Description_45 = "Время вычислителя и ПК отличаются более чем на 10 минут" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 18, Description = "Скорость ротора счётчика стала нормальной", Description_45 = "Скорость ротора счётчика стала нормальной" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 146, Description = "Скорость ротора счётчика стала выше допустимой", Description_45 = "Скорость ротора счётчика стала выше допустимой" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 19, Description = "Условия для расчёта F стали нормальными", Description_45 = "Условия для расчёта F стали нормальными" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 147, Description = "Условия для расчёта F стали ненормальными", Description_45 = "Условия для расчёта F стали ненормальными" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 20, Description = "Конец использования нижнего ПД", Description_45 = "Конец использования дифманометра нижнего перепада" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 148, Description = "Начало использования нижнего ПД", Description_45 = "Начало использования дифманометра нижнего перепада" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 21, Description = "Изменена калибровка канала", Description_45 = "Изменена калибровка канала" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 22, Description = "ПДВ ниже верхнего предела измерений", Description_45 = "ПДВ ниже верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 150, Description = "ПДВ выше верхнего предела измерений", Description_45 = "ПДВ выше верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 23, Description = "Давление стало ниже верхнего предела измерений", Description_45 = "Давление стало ниже верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 151, Description = "Давление стало выше верхнего предела измерений", Description_45 = "Давление стало выше верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 24, Description = "Температура стала выше -25 °С", Description_45 = "Температура стала выше -25 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 152, Description = "Температура стала ниже -25 °С", Description_45 = "Температура стала ниже -25 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 25, Description = "Абсолютное давление стало ниже или равно ВМП", Description_45 = "Абсолютное давление стало ниже или равно ВМП" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 153, Description = "Абсолютное давление стало выше ВМП", Description_45 = "Абсолютное давление стало выше ВМП" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 26, Description = "Температура стала выше -30 °С", Description_45 = "Температура стала выше -30 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 154, Description = "Температура стала ниже -30 °С", Description_45 = "Температура стала ниже -30 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 27, Description = "Коэффициент Ксж в норме, конец замены предыдущим значением", Description_45 = "Коэффициент Ксж в норме, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 155, Description = "Коэффициент Ксж меньше 0, начало замены предыдущим значением", Description_45 = "Коэффициент Ксж меньше 0, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 28, Description = "Абсолютное давление выше минимального атмосферного давления, конец замены предыдущим значением", Description_45 = "Абсолютное давление выше минимального атмосферного давления, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 156, Description = "Абсолютное давление ниже минимального атмосферного давления, начало замены предыдущим значением", Description_45 = "Абсолютное давление ниже минимального атмосферного давления, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 29, Description = "Вязкость в норме, конец замены предыдущим значением", Description_45 = "Вязкость в норме, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 157, Description = "Вязкость не в норме, начало замены предыдущим значением", Description_45 = "Вязкость не в норме, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 30, Description = "Значение не NAN, конец замены предыдущим значением", Description_45 = "Значение не NAN, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 158, Description = "Значение NAN, начало замены предыдущим значением", Description_45 = "Значение NAN, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 31, Description = "Значение меньше максимально допустимого, конец замены предыдущим значением", Description_45 = "Значение меньше максимально допустимого, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 159, Description = "Значение выше максимально допустимого, начало замены предыдущим значением", Description_45 = "Значение выше максимально допустимого, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 32, Description = "Значение выше минимально допустимого, конец замены предыдущим значением", Description_45 = "Значение выше минимально допустимого, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 160, Description = "Значение ниже минимально допустимого, начало замены предыдущим значением", Description_45 = "Значение ниже минимально допустимого, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 33, Description = "Конец обратного потока, конец замены предыдущим значением", Description_45 = "Конец обратного потока, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 161, Description = "Начало обратного потока, начало замены предыдущим значением", Description_45 = "Начало обратного потока, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 34, Description = "Единицы измерения в норме, конец замены предыдущим значением", Description_45 = "Единицы измерения в норме, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 162, Description = "Единицы измерения не в норме, начало замены предыдущим значением", Description_45 = "Единицы измерения не в норме, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 149, Description = "Ошибка опроса датчика", Description_45 = "Ошибка опроса датчика" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 39, Description = "ПДН стал ниже верхнего предела измерений", Description_45 = "ПДН стал ниже верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 167, Description = "ПДН стал выше верхнего предела измерений", Description_45 = "ПДН стал выше верхнего предела измерений" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 40, Description = "Подано напряжение питания", Description_45 = "Подано напряжение питания" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 168, Description = "Снято напряжение питания", Description_45 = "Снято напряжение питания" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 41, Description = "Конфигурирование вычислителя", Description_45 = "Конфигурирование вычислителя" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 42, Description = "Абсолютное давление стало выше или равно НМП", Description_45 = "Абсолютное давление стало выше или равно НМП" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 170, Description = "Абсолютное давление стало ниже НМП", Description_45 = "Абсолютное давление стало ниже НМП" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 43, Description = "Температура стала ниже 66.85 °С", Description_45 = "Температура стала ниже 66.85 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 171, Description = "Температура стала выше 66.85 °С", Description_45 = "Температура стала выше 66.85 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 44, Description = "Температура стала выше -23.15 °С", Description_45 = "Температура стала выше -23.15 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 172, Description = "Температура стала ниже -23.15 °С", Description_45 = "Температура стала ниже -23.15 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 35, Description = "Установка нуля канала", Description_45 = "Установка нуля канала" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 36, Description = "Абсолютное давление стало ниже 100 кгс/см2", Description_45 = "Абсолютное давление стало ниже 100 кгс/см2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 164, Description = "Абсолютное давление стало выше 100 кгс/см2", Description_45 = "Абсолютное давление стало выше 100 кгс/см2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 37, Description = "Конец режима 'заморозки'", Description_45 = "Конец режима 'заморозки'" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 165, Description = "Начало режима 'заморозки'", Description_45 = "Начало режима 'заморозки'" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 38, Description = "Конец использования НСХП канала", Description_45 = "Конец использования НСХП канала" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 166, Description = "Начало использования НСХП канала", Description_45 = "Начало использования НСХП канала" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 45, Description = "Расчёт плотности в норме, конец замены предыдущим значением", Description_45 = "Расчёт плотности в норме, конец замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 173, Description = "Расчёт плотности не в норме, начало замены предыдущим значением", Description_45 = "Расчёт плотности не в норме, начало замены предыдущим значением" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 50, Description = "Температура сенсора SMV стала нормальной", Description_45 = "Температура сенсора SMV стала нормальной" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 178, Description = "Температура сенсора SMV стала выше нормы", Description_45 = "Температура сенсора SMV стала выше нормы" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 51, Description = "Температура стала ниже 40 °С", Description_45 = "Температура стала ниже 40 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 179, Description = "Температура стала выше 40 °С", Description_45 = "Температура стала выше 40 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 52, Description = "Температура стала выше -10 °С", Description_45 = "Температура стала выше -10 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 180, Description = "Температура стала ниже -10 °С", Description_45 = "Температура стала ниже -10 °С" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 53, Description = "Абсолютное давление стало выше 11 кгс/см2", Description_45 = "Абсолютное давление стало выше 11 кгс/см2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 181, Description = "Абсолютное давление стало ниже 11 кгс/см2", Description_45 = "Абсолютное давление стало ниже 11 кгс/см2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 54, Description = "Абсолютное давление стало ниже 26 кгс/см2", Description_45 = "Абсолютное давление стало ниже 26 кгс/см2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 182, Description = "Абсолютное давление стало выше 26 кгс/см2", Description_45 = "Абсолютное давление стало выше 26 кгс/см2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 55, Description = "Значение стало выше НМП", Description_45 = "Значение стало выше НМП" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 183, Description = "Значение стало ниже НМП", Description_45 = "Значение стало ниже НМП" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 56, Description = "Значение стало ниже ВМП", Description_45 = "Значение стало ниже ВМП" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 184, Description = "Значение стало выше ВМП", Description_45 = "Значение стало выше ВМП" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 57, Description = "Значение стало выше НПИ", Description_45 = "Значение стало выше НПИ" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 185, Description = "Значение стало ниже НПИ", Description_45 = "Значение стало ниже НПИ" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 58, Description = "Значение стало ниже ВПИ", Description_45 = "Значение стало ниже ВПИ" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 186, Description = "Значение стало выше ВПИ", Description_45 = "Значение стало выше ВПИ" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 8, Description = "Расчёт по ГОСТ 8.586 стал возможным", Description_45 = "Корректный расчёт Кш стал возможным" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 136, Description = "Расчёт по ГОСТ 8.586 стал невозможным", Description_45 = "Корректный расчёт Кш стал невозможным" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 9, Description = "Запись во FLASH-память не выполнена", Description_45 = "Запись во FLASH-память не выполнена" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 137, Description = "Запись в буфер FLASH-памяти не выполнена", Description_45 = "Запись в буфер FLASH-памяти не выполнена" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 46, Description = "Аккумулятор КВВ в норме", Description_45 = "Аккумулятор КВВ в норме" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 174, Description = "Аккумулятор КВВ разряжен", Description_45 = "Аккумулятор КВВ разряжен" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 59, Description = "Расчётная частота на импульсном выходе в норме", Description_45 = "Расчётная частота на импульсном выходе в норме" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 187, Description = "Расчётная частота на импульсном выходе выше максимально допустимой", Description_45 = "Расчётная частота на импульсном выходе выше максимально допустимой" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 60, Description = "Карта памяти присутствует", Description_45 = "Карта памяти присутствует" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 188, Description = "Карта памяти отсутствует", Description_45 = "Карта памяти отсутствует" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 61, Description = "Карта памяти исправна", Description_45 = "Карта памяти исправна" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 189, Description = "Карта памяти неисправна", Description_45 = "Карта памяти неисправна" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 62, Description = "Карта памяти подготовлена", Description_45 = "Карта памяти подготовлена" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 190, Description = "Карта памяти не подготовлена", Description_45 = "Карта памяти не подготовлена" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 63, Description = "Обнаружен повреждённый кластер", Description_45 = "Обнаружен повреждённый кластер" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 191, Description = "Все кластеры в норме", Description_45 = "Все кластеры в норме" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 64, Description = "Запись во FLASH-память выполнена", Description_45 = "Запись во FLASH-память выполнена" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 192, Description = "Запись во FLASH-память не выполнена", Description_45 = "Запись во FLASH-память не выполнена" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 47, Description = "Значение расхода при р.у. стало выше значения, при котором счётчик останавливается", Description_45 = "Значение расхода при р.у. стало выше значения, при котором счётчик останавливается" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 175, Description = "Значение расхода при р.у. стало ниже значения, при котором счётчик останавливается", Description_45 = "Значение расхода при р.у. стало ниже значения, при котором счётчик останавливается" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 65, Description = "Значение скорости потока стало ниже максимально допустимого", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 193, Description = "Значение скорости потока стало выше максимально допустимого", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 66, Description = "Опрос ультразвукового счётчика в норме", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 194, Description = "Опрос ультразвукового счётчика не в норме", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 67, Description = "Изменена карта регистров ошибок", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 195, Description = "Ультразвуковой счётчик: неожиданное значение объёма", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 68, Description = "Ультразвуковой счётчик: неожиданное значение аварийного объёма", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 48, Description = "Проток одоранта в норме", Description_45 = "Проток одоранта в норме" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 176, Description = "Проток одоранта отсутствует", Description_45 = "Проток одоранта отсутствует" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 49, Description = "ЭППЗУ КВВ в норме", Description_45 = "ЭППЗУ КВВ в норме" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 177, Description = "ЭППЗУ КВВ исчерпало ресурс", Description_45 = "ЭППЗУ КВВ исчерпало ресурс" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 163, Description = "Изменено смещение в канале", Description_45 = "Изменено смещение в канале" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 169, Description = "", Description_45 = "Изменены параметры АЦП" });

            alarmsTypes.ForEach((a) => { context.FloutecAlarmsTypes.Add(a); });

            #endregion

            #region Инициализация типов вмешательств для вычислителей ФЛОУТЭК

            List<FloutecIntersTypes> intersTypes = new List<FloutecIntersTypes>();

            intersTypes.Add(new FloutecIntersTypes() { Code = 0, Description = "Наименование трубопровода", Description_45 = "Наименование трубопровода" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 1, Description = "Плотность, кг/м3", Description_45 = "Плотность, кг/м3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 2, Description = "Молярная доля СО2, %", Description_45 = "Молярная доля СО2, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 3, Description = "Молярная доля N2, %", Description_45 = "Молярная доля N2, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 4, Description = "Диаметр трубопровода, мм", Description_45 = "Диаметр трубопровода, мм" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 5, Description = "Диаметр СУ, мм", Description_45 = "Диаметр СУ, мм" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 6, Description = "Атмосферное давление, мм рт. ст.", Description_45 = "Атмосферное давление, мм рт. ст." });
            intersTypes.Add(new FloutecIntersTypes() { Code = 7, Description = "Отсечка ПД, кг/м2", Description_45 = "Отсечка ПД, кг/м2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 8, Description = "Минимальный расход (Qmin), м3/час", Description_45 = "Минимальный расход (Qmin), м3/час" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 9, Description = "ВПИ расхода (Qmax), м3/час", Description_45 = "ВПИ расхода (Qmax), м3/час" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 10, Description = "Наименование объекта", Description_45 = "Наименование объекта" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 11, Description = "Порог переключения перепада давления, кг/м2", Description_45 = "Порог переключения перепада давления, кг/м2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 12, Description = "Тип отбора перепада давления", Description_45 = "Тип отбора перепада давления" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 13, Description = "Удельная теплота сгорания", Description_45 = "Удельная теплота сгорания" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 14, Description = "Объём газа на 1 выходной импульс, м3", Description_45 = "Объём газа на 1 выходной импульс, м3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 15, Description = "Изменены параметры доступа пользователя", Description_45 = "Калибровка нуля перепада давления" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 16, Description = "Калибровка нуля нижнего перепада давления", Description_45 = "Калибровка нуля нижнего перепада давления" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 17, Description = "Номер скважины", Description_45 = "Калибровка нуля верхнего перепада давления" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 18, Description = "Вязкость конденсата, мкН*с/м2", Description_45 = "Вязкость конденсата, мкН*с/м2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 19, Description = "Шероховатость трубы, мм", Description_45 = "Шероховатость трубы, мм" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 20, Description = "Коэффициент Ае (а0*1е-06) для расчёта Ктлр СУ", Description_45 = "Коэффициент Ае (а0*1е-06) для расчёта Ктлр СУ" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 21, Description = "Коэффициент Ве (а1*1е-09) для расчёта Ктлр СУ", Description_45 = "Коэффициент Ве (а1*1е-09) для расчёта Ктлр СУ" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 22, Description = "Ктлр материала диафрагмы", Description_45 = "Ктлр материала диафрагмы" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 23, Description = "Коэффициент Се (а2*1е-12) для расчёта Ктлр СУ", Description_45 = "Коэффициент Се (а2*1е-12) для расчёта Ктлр СУ" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 24, Description = "Ктлр материала трубы", Description_45 = "Ктлр материала трубы" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 25, Description = "Минимально допустимое напряжение №1", Description_45 = "Минимально допустимое напряжение №1" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 26, Description = "Минимально допустимое напряжение №2", Description_45 = "Минимально допустимое напряжение №2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 27, Description = "Минимально допустимое напряжение №3", Description_45 = "Минимально допустимое напряжение №3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 28, Description = "Когда на летнее время", Description_45 = "Когда на летнее время" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 29, Description = "Когда на зимнее время", Description_45 = "Когда на зимнее время" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 30, Description = "Время - переход на летнее", Description_45 = "Время - переход на летнее" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 31, Description = "Время - переход на зимнее", Description_45 = "Время - переход на зимнее" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 32, Description = "Оперативный интревал", Description_45 = "Оперативный интревал" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 33, Description = "Коэффициент Ае (а0*1е-06) для расчёта Ктлр трубы", Description_45 = "Коэффициент Ае (а0*1е-06) для расчёта Ктлр трубы" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 34, Description = "Коэффициент Ве (а1*1е-09) для расчёта Ктлр трубы", Description_45 = "Коэффициент Ве (а1*1е-09) для расчёта Ктлр трубы" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 35, Description = "Коэффициент Се (а2*1е-12) для расчёта Ктлр трубы", Description_45 = "Коэффициент Се (а2*1е-12) для расчёта Ктлр трубы" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 36, Description = "Счётчик десятков млн. м3 объёма при р.у.", Description_45 = "Счётчик объёмов по 10 тыс. м3 при р.у. по модулю 10000000" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 37, Description = "Объём при р.у., м3", Description_45 = "Объём при р.у. по модулю 10000, м3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 38, Description = "Тип ОНТ", Description_45 = "Тип ОНТ" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 39, Description = "Модель ОНТ ITABAR", Description_45 = "Модель ОНТ ITABAR" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 40, Description = "Модель ОНТ ANNUBAR", Description_45 = "Ширина зонда в свете, мм" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 41, Description = "Единица измерений давления", Description_45 = "Единица измерений давления" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 42, Description = "Единица измерений перепада давления", Description_45 = "Единица измерений перепада давления" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 43, Description = "Единица измерений атмосферного давления", Description_45 = "Единица измерений атмосферного давления" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 44, Description = "Тип статического давления", Description_45 = "Тип статического давления" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 45, Description = "Необходимость пароля для чтения данных", Description_45 = "Необходимость пароля для чтения данных" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 46, Description = "Период калибровки АЦП при работе", Description_45 = "Период калибровки АЦП при работе" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 47, Description = "Период калибровки АЦП при калибровке", Description_45 = "Период калибровки АЦП при калибровке" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 48, Description = "ВПИ перепада давления, кГс/м2", Description_45 = "ВПИ перепада давления, кГс/м2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 49, Description = "НПИ давления, кГс/см2", Description_45 = "НПИ давления, кГс/см2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 50, Description = "ВПИ давления, кГс/см2", Description_45 = "ВПИ давления, кГс/см2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 51, Description = "НПИ температуры, °С", Description_45 = "НПИ температуры, °С" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 52, Description = "ВПИ температуры, °С", Description_45 = "ВПИ температуры, °С" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 53, Description = "Количество импульсов на 1 м3", Description_45 = "Количество импульсов на 1 м3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 54, Description = "Максимально возможное давление, кГс/см2", Description_45 = "Максимально возможное давление, кГс/см2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 55, Description = "Расход, при котором счётчик останавливается, м3/час", Description_45 = "Расход, при котором счётчик останавливается, м3/час" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 56, Description = "Максимально допускаемый расход при р.у., м3/час", Description_45 = "Максимально допускаемый расход при р.у., м3/час" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 57, Description = "Максимально возможный перепад давления, кГс/м2", Description_45 = "Максимально возможный перепад давления, кГс/м2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 58, Description = "НПИ перепада давления, кГс/м2", Description_45 = "НПИ перепада давления, кГс/м2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 59, Description = "НПИ плотности", Description_45 = "НПИ плотности" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 60, Description = "ВПИ плотности", Description_45 = "ВПИ плотности" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 61, Description = "Использование НСХП цифрового канала Д", Description_45 = "Использование НСХП цифрового канала Д" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 62, Description = "Использование НСХП цифрового канала Т", Description_45 = "Использование НСХП цифрового канала Т" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 63, Description = "Использование НСХП цифрового канала ПД", Description_45 = "Использование НСХП цифрового канала ПД" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 64, Description = "Использование НСХП цифрового канала ПДН", Description_45 = "Использование НСХП цифрового канала ПДН" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 65, Description = "Санкционированное использование НСХП цифрового канала Д", Description_45 = "Санкционированное использование НСХП цифрового канала Д" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 66, Description = "Санкционированное использование НСХП цифрового канала Т", Description_45 = "Санкционированное использование НСХП цифрового канала Т" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 67, Description = "Санкционированное использование НСХП цифрового канала ПД", Description_45 = "Санкционированное использование НСХП цифрового канала ПД" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 68, Description = "Санкционированное использование НСХП цифрового канала ПДН", Description_45 = "Санкционированное использование НСХП цифрового канала ПДН" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 69, Description = "Несанкционированное использование НСХП цифрового канала Д", Description_45 = "Несанкционированное использование НСХП цифрового канала Д" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 70, Description = "Несанкционированное использование НСХП цифрового канала Т", Description_45 = "Несанкционированное использование НСХП цифрового канала Т" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 71, Description = "Несанкционированное использование НСХП цифрового канала ПД", Description_45 = "Несанкционированное использование НСХП цифрового канала ПД" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 72, Description = "Несанкционированное использование НСХП цифрового канала ПДН", Description_45 = "Несанкционированное использование НСХП цифрового канала ПДН" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 128, Description = "Время", Description_45 = "Время" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 129, Description = "Калибровочный коэффициент ОНТ", Description_45 = "Калибровочный коэффициент ОНТ" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 130, Description = "Период цикла опроса, сек.", Description_45 = "Период цикла опроса, сек." });
            intersTypes.Add(new FloutecIntersTypes() { Code = 131, Description = "Контрактный час", Description_45 = "Контрактный час" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 132, Description = "Минимально допускаемое число Re", Description_45 = "Минимально допускаемое число Re" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 133, Description = "Параметры НСХП канала Д", Description_45 = "Параметры НСХП канала Д" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 134, Description = "Параметры НСХП канала Т", Description_45 = "Параметры НСХП канала Т" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 135, Description = "Параметры НСХП канала ПД", Description_45 = "Параметры НСХП канала ПД" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 136, Description = "Параметры НСХП канала ПДВ", Description_45 = "Параметры НСХП канала ПДВ" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 137, Description = "Параметры НСХП канала ПДН", Description_45 = "Параметры НСХП канала ПДН" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 138, Description = "Ширина зонда в свету, мм", Description_45 = "Константа коэффициента расширения" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 139, Description = "Метод измерений", Description_45 = "Метод измерений" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 141, Description = "Управление одорантом", Description_45 = "Управление одорантом" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 142, Description = "Начальный радиус входной кромки диафрагмы, мм", Description_45 = "Начальный радиус входной кромки диафрагмы, мм" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 143, Description = "Межконтрольный интервал СУ", Description_45 = "Межконтрольный интервал СУ" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 144, Description = "Постановка на константу", Description_45 = "Постановка на константу" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 145, Description = "Снятие с константы", Description_45 = "Снятие с константы" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 146, Description = "Параметры калибровки", Description_45 = "Параметры калибровки" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 147, Description = "Смещение ПД", Description_45 = "Смещение ПД" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 148, Description = "Коэффициент наклона ПД", Description_45 = "Коэффициент наклона ПД" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 149, Description = "Смещение Т", Description_45 = "Смещение Д" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 150, Description = "Коэффициент наклона Т", Description_45 = "Коэффициент наклона Д" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 151, Description = "Установка нуля", Description_45 = "Установка нуля" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 152, Description = "Параметры АЦП", Description_45 = "Параметры АЦП" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 153, Description = "Константа Д (санкционированное изменение)", Description_45 = "Константа Д (санкционированное изменение)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 154, Description = "Константа Т (санкционированное изменение)", Description_45 = "Константа Т (санкционированное изменение)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 155, Description = "Константа (санкционированное изменение)", Description_45 = "Константа (санкционированное изменение)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 156, Description = "Константа П (санкционированное изменение)", Description_45 = "Константа П (санкционированное изменение)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 157, Description = "Константа Д (несанкционированное изменение)", Description_45 = "Константа Д (несанкционированное изменение)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 158, Description = "Константа Т (несанкционированное изменение)", Description_45 = "Константа Т (несанкционированное изменение)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 159, Description = "Константа (несанкционированное изменение)", Description_45 = "Константа (несанкционированное изменение)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 160, Description = "Константа П (несанкционированное изменение)", Description_45 = "Константа П (несанкционированное изменение)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 161, Description = "Норма одоранта, мг/нм3", Description_45 = "Норма одоранта, мг/нм3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 162, Description = "Максимальная доза одоранта, см3", Description_45 = "Максимальная доза одоранта, см3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 168, Description = "Объём одоранта, соответствующий одному циклу", Description_45 = "Объём камеры расходомера" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 169, Description = "Отсчёт по шкале дозатора", Description_45 = "Отсчёт по шкале дозатора" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 170, Description = "Плотность одоранта, г/см3", Description_45 = "Плотность одоранта, г/см3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 171, Description = "Концентрация меркаптановой серы, г/тыс. м3", Description_45 = "Концентрация меркаптановой серы, г/тыс. м3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 172, Description = "Молярная доля метана СН4, %", Description_45 = "Молярная доля метана СН4, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 173, Description = "Молярная доля этана С2Н6, %", Description_45 = "Молярная доля этана С2Н6, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 174, Description = "Молярная доля пропана С3Н8, %", Description_45 = "Молярная доля пропана С3Н8, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 175, Description = "Молярная доля бутана С4Н10, %", Description_45 = "Молярная доля бутана С4Н10, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 176, Description = "Молярная доля пентана С5Н12, %", Description_45 = "Молярная доля пентана С5Н12, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 177, Description = "Молярная доля сероводорода H2S, %", Description_45 = "Молярная доля сероводорода H2S, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 178, Description = "Параметры преобразователя", Description_45 = "Параметры преобразователя" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 179, Description = "Постановка на константу", Description_45 = "Постановка на константу" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 180, Description = "Снятие с константы", Description_45 = "Снятие с константы" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 181, Description = "Константа Д", Description_45 = "Константа Д" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 182, Description = "Константа Т", Description_45 = "Константа Т" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 183, Description = "Константа", Description_45 = "Константа" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 184, Description = "Константа П", Description_45 = "Константа П" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 185, Description = "Максимально допускаемая скорость потока, м/с", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 186, Description = "Адрес регистров расхода", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 187, Description = "Адрес регистров объёма", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 188, Description = "Адрес регистров скорости потока", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 189, Description = "Порядок байтов по протоколу MODBUS", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 190, Description = "Режим работы по протоколу MODBUS", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 191, Description = "Адрес регистра разрешения счётчика", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 192, Description = "Адрес регистра аварийного объёма", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 193, Description = "Адрес ультразвукового счётчика", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 194, Description = "Порядок байтов переменных в ответе функции 6", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 195, Description = "Конфигурация импульсного выхода №1", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 196, Description = "Конфигурация импульсного выхода №2", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 197, Description = "Конфигурация импульсного выхода №3", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 198, Description = "Длинный адрес ЦП", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 199, Description = "Адрес вычислителя", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 200, Description = "Счётчик десятков млн. м3 в показаниях счётчика по обратному потоку", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 201, Description = "Объём (меньше 10 млн. м3) в показаниях счётчика по обратному потоку", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 202, Description = "Конфигурация линий подключения ЦП", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 203, Description = "Объём газа на 1 импульс для импульсного выхода №1, м3", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 204, Description = "Объём газа на 1 импульс для импульсного выхода №2, м3", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 205, Description = "Объём газа на 1 импульс для импульсного выхода №3, м3", Description_45 = "" });

            intersTypes.ForEach((i) => { context.FloutecIntersTypes.Add(i); });

            #endregion

            #region Инициализация типов датчиков для вычислителей ФЛОУТЭК

            List<FloutecSensorsTypes> sensorsTypes = new List<FloutecSensorsTypes>();

            sensorsTypes.Add(new FloutecSensorsTypes() { Code = 1, Name = "Диафрагма" });
            sensorsTypes.Add(new FloutecSensorsTypes() { Code = 2, Name = "Счётчик" });
            sensorsTypes.Add(new FloutecSensorsTypes() { Code = 3, Name = "Массовый расходомер" });

            sensorsTypes.ForEach((s) => { context.FloutecSensorsTypes.Add(s); });

            #endregion

            #region Инициализация типов событий вычислителей ROC809

            List<ROC809EventsTypes> eventsTypes = new List<ROC809EventsTypes>();

            eventsTypes.Add(new ROC809EventsTypes() { Code = 0, Description = "Событие отсутствует" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 1, Description = "Событие изменения параметра" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 2, Description = "Системное событие" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 3, Description = "Событие таблицы последовательности функций (FST)" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 4, Description = "Пользовательское событие" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 5, Description = "Событие потери питания" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 6, Description = "Событие установки часов" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 7, Description = "Событие проверки калибровки" });

            eventsTypes.ForEach((e) => { context.ROC809EventsTypes.Add(e); });

            List<ROC809EventsCodes> eventsCodes = new List<ROC809EventsCodes>();

            eventsCodes.Add(new ROC809EventsCodes() { Code = 144, Description = "Последовательность инициализации" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 145, Description = "Отключено всё питание" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 146, Description = "Инициализация значениями по умолчанию" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 147, Description = "Ошибка контрольной суммы ПЗУ" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 148, Description = "Инициализация базы данных" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 150, Description = "Программирование FLASH-памяти" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 151, Description = "Зарезервировано для ROC809" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 152, Description = "Зарезервировано для ROC809" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 153, Description = "Зарезервировано для ROC809" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 154, Description = "Добавлен SMART-модуль" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 155, Description = "Удалён SMART-модуль" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 200, Description = "Установка часов" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 248, Description = "Текстовое сообщение" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 249, Description = "Конфигурирование загрузки" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 250, Description = "Конфигурирование выгрузки" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 251, Description = "Таймаут калибровки" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 252, Description = "Отмена калибровки" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 253, Description = "Сброс мультисегментной виртуальной памяти (MVS) к заводским настройкам" });

            eventsCodes.ForEach((e) => { context.ROC809EventsCodes.Add(e); });

            #endregion Инициализация типов аварий вычислителей ROC809

            List<ROC809AlarmsTypes> rocAlarmsTypes = new List<ROC809AlarmsTypes>();

            rocAlarmsTypes.Add(new ROC809AlarmsTypes() { Code = 0, Description = "Авария отсутствует" });
            rocAlarmsTypes.Add(new ROC809AlarmsTypes() { Code = 1, Description = "Авария параметра" });
            rocAlarmsTypes.Add(new ROC809AlarmsTypes() { Code = 2, Description = "Авария таблицы последовательности функций (FST)" });
            rocAlarmsTypes.Add(new ROC809AlarmsTypes() { Code = 3, Description = "Авария пользовательского текста" });
            rocAlarmsTypes.Add(new ROC809AlarmsTypes() { Code = 4, Description = "Авария пользовательского значения" });

            rocAlarmsTypes.ForEach((a) => { context.ROC809AlarmsTypes.Add(a); });

            List<ROC809AlarmsCodes> rocAlarmsCodes = new List<ROC809AlarmsCodes>();

            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 0, Description = "Авария нижней предупредительной границы" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 1, Description = "Авария нижней аварийной границы" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 2, Description = "Авария верхней предупредительной границы" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 3, Description = "Авария верхней аварийной границы" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 4, Description = "Авария скорости изменения значения" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 5, Description = "Изменение статуса" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 6, Description = "Ошибка точки измерения" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 7, Description = "Сканирование отключено" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 8, Description = "Сканирование в ручном режиме" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 9, Description = "Переполнение суммирующих счётчиков" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 10, Description = "Переполнение регистра потока" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 11, Description = "Отсутствие потока" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 12, Description = "Режим 'заморозки' входов" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 13, Description = "Ошибка соединения с сенсором" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 14, Description = "Ошибка соединения интерфейса RS-485" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 15, Description = "Режим отключения сканирования" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 16, Description = "Ошибка температуры измерителя" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 17, Description = "Переполнение регистра потока" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 18, Description = "Ошибка расчёта сжимаемости" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 19, Description = "Сбой последовательности" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 20, Description = "Перекос фаз" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 21, Description = "Ошибка синхронизации импульсов" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 22, Description = "Несоответствие частот" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 23, Description = "Ошибка импульсного входа №1" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 24, Description = "Ошибка импульсного входа №2" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 25, Description = "Переполнение буфера импульсного выхода" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 26, Description = "Предупреждение о переполнении буфера импульсного выхода" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 27, Description = "Неисправность реле" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 28, Description = "Ошибка реле" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 29, Description = "Ограничение статического давления снизу" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 30, Description = "Ограничение температуры снизу" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 31, Description = "Ошибка обратной связи аналогового выхода" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 32, Description = "Плохой уровень потока импульсов" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 33, Description = "Авария импульса масштабной отметки" });

            rocAlarmsCodes.ForEach((a) => { context.ROC809AlarmsCodes.Add(a); });

            #region

            #endregion

            #region Инициализация установок

            List<Field> fields = new List<Field>();

            fields.Add(new Field() { DateCreated = DateTime.Now, DateModified = DateTime.Now, IsDeleted = false, Id = 1, Name = "SEM-SRV", Description = "УКПГ Семиренки" });
            fields.Add(new Field() { DateCreated = DateTime.Now, DateModified = DateTime.Now, IsDeleted = false, Id = 2, Name = "OLEF-SRV", Description = "УППГ Олефировка" });
            fields.Add(new Field() { DateCreated = DateTime.Now, DateModified = DateTime.Now, IsDeleted = false, Id = 3, Name = "MACH-SRV", Description = "УПГ Мачухи" });

            fields.ForEach((f) => { context.Fields.Add(f); });

            #endregion

            base.Seed(context);
        }
    }
}
