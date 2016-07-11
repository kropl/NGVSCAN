namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using CORE.Entities;
    using CORE.Entities.Floutecs.Common;
    using CORE.Entities.ROC809s.Common;
    internal sealed class Configuration : DbMigrationsConfiguration<NGVSCAN.DAL.Context.NGVSCANContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NGVSCAN.DAL.Context.NGVSCANContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            #region ������������� ����� ���������� ��� ������������ �������

            List<FloutecParamsTypes> paramsTypes = new List<FloutecParamsTypes>();

            paramsTypes.Add(new FloutecParamsTypes() { Code = 0, Param = "�", Description = "��������" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 1, Param = "�", Description = "�����������" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 2, Param = "��", Description = "������� ��������" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 3, Param = "���", Description = "������� �������� ������" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 4, Param = "���", Description = "������� �������� �������" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 5, Param = "����", Description = "������ ��������� �� ����������" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 7, Param = "�", Description = "���������" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 8, Param = "����,�", Description = "������ ��������� �� ����������, ����������� ����� � ����������" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 11, Param = "��,�", Description = "������� ��������, ��������" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 15, Param = "��,�,�", Description = "������� ��������, ��������, �����������" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 39, Param = "�", Description = "������" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 40, Param = "�", Description = "�������" });
            paramsTypes.Add(new FloutecParamsTypes() { Code = 42, Param = "�,�,�", Description = "������, �����������, ���������" });

            paramsTypes.ForEach((p) => { context.FloutecParamsTypes.AddOrUpdate(p); });

            #endregion

            #region ������������� ����� ������ ��� ������������ �������

            List<FloutecAlarmsTypes> alarmsTypes = new List<FloutecAlarmsTypes>();

            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 0, Description = "����� � �����, ����� ������ ���������� ���������", Description_45 = "����� � �����, ����� ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 128, Description = "����� �� � �����, ������ ������ ���������� ���������", Description_45 = "����� �� � �����, ������ ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 1, Description = "����� ������������ ������", Description_45 = "����� ������������ ���� ������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 129, Description = "������ ������������ ������", Description_45 = "������ ������������ ���� ������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 2, Description = "������� �������� ���� �������� �������", Description_45 = "������� �������� ���� �������� �������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 130, Description = "������� �������� ���� ��� ����� �������", Description_45 = "������� �������� ���� ��� ����� �������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 3, Description = "����� ������ ��������� ����������", Description_45 = "����� ������ ��������� ����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 4, Description = "����� ������ ��������� ������������������� ����������", Description_45 = "����� ������ ��������� ������������������� ����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 132, Description = "������ ������ ��������� ������������������� ����������", Description_45 = "������ ������ ��������� ������������������� ����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 131, Description = "������ ������ ��������� ����������", Description_45 = "������ ������ ��������� ����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 5, Description = "���������� ������� ����� ����������", Description_45 = "���������� ������� ����� ����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 133, Description = "���������� ������� ���� �������", Description_45 = "���������� ������� ���� �������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 6, Description = "������� �������� ���� ���� �������� ������� ���������", Description_45 = "������� �������� ���� ���� �������� ������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 134, Description = "������� �������� ���� ���� �������� ������� ���������", Description_45 = "������� �������� ���� ���� �������� ������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 7, Description = "������ ��������� ����������� ����� ����������������, ������ ���������� ������� �����������", Description_45 = "������ ��������� ����������� ����� ����������������, ������ ���������� ������� �����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 135, Description = "����� ���������� ������� �����������", Description_45 = "����� ���������� ������� �����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 138, Description = "������ �����/��������� ������������", Description_45 = "������ �����/��������� ������������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 11, Description = "��������� ��/� ����� ����������", Description_45 = "��������� ��/� ����� ����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 139, Description = "��������� ��/� �� � �����", Description_45 = "��������� ��/� �� � �����" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 12, Description = "Re ����� ����������", Description_45 = "Re ����� ����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 140, Description = "Re ����� �� ����������� �������", Description_45 = "Re ����� �� ����������� �������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 13, Description = "����� ������� �� 0, ����� ������ ���������� ���������", Description_45 = "����� ������� �� 0, ����� ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 141, Description = "������ ������� �� 0, ������ ������ ���������� ���������", Description_45 = "������ ������� �� 0, ������ ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 14, Description = "����� ������ �� ������������", Description_45 = "����� ������ �� ������������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 142, Description = "������ ������ �� ������������", Description_45 = "������ ������ �� ������������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 15, Description = "����������� ����� ���� -40 ��", Description_45 = "����������� ����� ���� -40 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 143, Description = "����������� ����� ���� -40 ��", Description_45 = "����������� ����� ���� -40 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 16, Description = "����������� ����� ���� 80 ��", Description_45 = "����������� ����� ���� 80 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 144, Description = "����������� ����� ���� 80 ��", Description_45 = "����������� ����� ���� 80 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 145, Description = "����� ����������� � �� ���������� ����� ��� �� 10 �����", Description_45 = "����� ����������� � �� ���������� ����� ��� �� 10 �����" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 18, Description = "�������� ������ �������� ����� ����������", Description_45 = "�������� ������ �������� ����� ����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 146, Description = "�������� ������ �������� ����� ���� ����������", Description_45 = "�������� ������ �������� ����� ���� ����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 19, Description = "������� ��� ������� F ����� �����������", Description_45 = "������� ��� ������� F ����� �����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 147, Description = "������� ��� ������� F ����� �������������", Description_45 = "������� ��� ������� F ����� �������������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 20, Description = "����� ������������� ������� ��", Description_45 = "����� ������������� ������������ ������� ��������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 148, Description = "������ ������������� ������� ��", Description_45 = "������ ������������� ������������ ������� ��������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 21, Description = "�������� ���������� ������", Description_45 = "�������� ���������� ������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 22, Description = "��� ���� �������� ������� ���������", Description_45 = "��� ���� �������� ������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 150, Description = "��� ���� �������� ������� ���������", Description_45 = "��� ���� �������� ������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 23, Description = "�������� ����� ���� �������� ������� ���������", Description_45 = "�������� ����� ���� �������� ������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 151, Description = "�������� ����� ���� �������� ������� ���������", Description_45 = "�������� ����� ���� �������� ������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 24, Description = "����������� ����� ���� -25 ��", Description_45 = "����������� ����� ���� -25 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 152, Description = "����������� ����� ���� -25 ��", Description_45 = "����������� ����� ���� -25 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 25, Description = "���������� �������� ����� ���� ��� ����� ���", Description_45 = "���������� �������� ����� ���� ��� ����� ���" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 153, Description = "���������� �������� ����� ���� ���", Description_45 = "���������� �������� ����� ���� ���" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 26, Description = "����������� ����� ���� -30 ��", Description_45 = "����������� ����� ���� -30 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 154, Description = "����������� ����� ���� -30 ��", Description_45 = "����������� ����� ���� -30 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 27, Description = "����������� ��� � �����, ����� ������ ���������� ���������", Description_45 = "����������� ��� � �����, ����� ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 155, Description = "����������� ��� ������ 0, ������ ������ ���������� ���������", Description_45 = "����������� ��� ������ 0, ������ ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 28, Description = "���������� �������� ���� ������������ ������������ ��������, ����� ������ ���������� ���������", Description_45 = "���������� �������� ���� ������������ ������������ ��������, ����� ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 156, Description = "���������� �������� ���� ������������ ������������ ��������, ������ ������ ���������� ���������", Description_45 = "���������� �������� ���� ������������ ������������ ��������, ������ ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 29, Description = "�������� � �����, ����� ������ ���������� ���������", Description_45 = "�������� � �����, ����� ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 157, Description = "�������� �� � �����, ������ ������ ���������� ���������", Description_45 = "�������� �� � �����, ������ ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 30, Description = "�������� �� NAN, ����� ������ ���������� ���������", Description_45 = "�������� �� NAN, ����� ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 158, Description = "�������� NAN, ������ ������ ���������� ���������", Description_45 = "�������� NAN, ������ ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 31, Description = "�������� ������ ����������� �����������, ����� ������ ���������� ���������", Description_45 = "�������� ������ ����������� �����������, ����� ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 159, Description = "�������� ���� ����������� �����������, ������ ������ ���������� ���������", Description_45 = "�������� ���� ����������� �����������, ������ ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 32, Description = "�������� ���� ���������� �����������, ����� ������ ���������� ���������", Description_45 = "�������� ���� ���������� �����������, ����� ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 160, Description = "�������� ���� ���������� �����������, ������ ������ ���������� ���������", Description_45 = "�������� ���� ���������� �����������, ������ ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 33, Description = "����� ��������� ������, ����� ������ ���������� ���������", Description_45 = "����� ��������� ������, ����� ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 161, Description = "������ ��������� ������, ������ ������ ���������� ���������", Description_45 = "������ ��������� ������, ������ ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 34, Description = "������� ��������� � �����, ����� ������ ���������� ���������", Description_45 = "������� ��������� � �����, ����� ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 162, Description = "������� ��������� �� � �����, ������ ������ ���������� ���������", Description_45 = "������� ��������� �� � �����, ������ ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 149, Description = "������ ������ �������", Description_45 = "������ ������ �������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 39, Description = "��� ���� ���� �������� ������� ���������", Description_45 = "��� ���� ���� �������� ������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 167, Description = "��� ���� ���� �������� ������� ���������", Description_45 = "��� ���� ���� �������� ������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 40, Description = "������ ���������� �������", Description_45 = "������ ���������� �������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 168, Description = "����� ���������� �������", Description_45 = "����� ���������� �������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 41, Description = "���������������� �����������", Description_45 = "���������������� �����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 42, Description = "���������� �������� ����� ���� ��� ����� ���", Description_45 = "���������� �������� ����� ���� ��� ����� ���" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 170, Description = "���������� �������� ����� ���� ���", Description_45 = "���������� �������� ����� ���� ���" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 43, Description = "����������� ����� ���� 66.85 ��", Description_45 = "����������� ����� ���� 66.85 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 171, Description = "����������� ����� ���� 66.85 ��", Description_45 = "����������� ����� ���� 66.85 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 44, Description = "����������� ����� ���� -23.15 ��", Description_45 = "����������� ����� ���� -23.15 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 172, Description = "����������� ����� ���� -23.15 ��", Description_45 = "����������� ����� ���� -23.15 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 35, Description = "��������� ���� ������", Description_45 = "��������� ���� ������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 36, Description = "���������� �������� ����� ���� 100 ���/��2", Description_45 = "���������� �������� ����� ���� 100 ���/��2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 164, Description = "���������� �������� ����� ���� 100 ���/��2", Description_45 = "���������� �������� ����� ���� 100 ���/��2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 37, Description = "����� ������ '���������'", Description_45 = "����� ������ '���������'" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 165, Description = "������ ������ '���������'", Description_45 = "������ ������ '���������'" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 38, Description = "����� ������������� ���� ������", Description_45 = "����� ������������� ���� ������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 166, Description = "������ ������������� ���� ������", Description_45 = "������ ������������� ���� ������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 45, Description = "������ ��������� � �����, ����� ������ ���������� ���������", Description_45 = "������ ��������� � �����, ����� ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 173, Description = "������ ��������� �� � �����, ������ ������ ���������� ���������", Description_45 = "������ ��������� �� � �����, ������ ������ ���������� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 50, Description = "����������� ������� SMV ����� ����������", Description_45 = "����������� ������� SMV ����� ����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 178, Description = "����������� ������� SMV ����� ���� �����", Description_45 = "����������� ������� SMV ����� ���� �����" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 51, Description = "����������� ����� ���� 40 ��", Description_45 = "����������� ����� ���� 40 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 179, Description = "����������� ����� ���� 40 ��", Description_45 = "����������� ����� ���� 40 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 52, Description = "����������� ����� ���� -10 ��", Description_45 = "����������� ����� ���� -10 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 180, Description = "����������� ����� ���� -10 ��", Description_45 = "����������� ����� ���� -10 ��" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 53, Description = "���������� �������� ����� ���� 11 ���/��2", Description_45 = "���������� �������� ����� ���� 11 ���/��2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 181, Description = "���������� �������� ����� ���� 11 ���/��2", Description_45 = "���������� �������� ����� ���� 11 ���/��2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 54, Description = "���������� �������� ����� ���� 26 ���/��2", Description_45 = "���������� �������� ����� ���� 26 ���/��2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 182, Description = "���������� �������� ����� ���� 26 ���/��2", Description_45 = "���������� �������� ����� ���� 26 ���/��2" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 55, Description = "�������� ����� ���� ���", Description_45 = "�������� ����� ���� ���" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 183, Description = "�������� ����� ���� ���", Description_45 = "�������� ����� ���� ���" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 56, Description = "�������� ����� ���� ���", Description_45 = "�������� ����� ���� ���" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 184, Description = "�������� ����� ���� ���", Description_45 = "�������� ����� ���� ���" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 57, Description = "�������� ����� ���� ���", Description_45 = "�������� ����� ���� ���" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 185, Description = "�������� ����� ���� ���", Description_45 = "�������� ����� ���� ���" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 58, Description = "�������� ����� ���� ���", Description_45 = "�������� ����� ���� ���" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 186, Description = "�������� ����� ���� ���", Description_45 = "�������� ����� ���� ���" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 8, Description = "������ �� ���� 8.586 ���� ���������", Description_45 = "���������� ������ �� ���� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 136, Description = "������ �� ���� 8.586 ���� �����������", Description_45 = "���������� ������ �� ���� �����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 9, Description = "������ �� FLASH-������ �� ���������", Description_45 = "������ �� FLASH-������ �� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 137, Description = "������ � ����� FLASH-������ �� ���������", Description_45 = "������ � ����� FLASH-������ �� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 46, Description = "����������� ��� � �����", Description_45 = "����������� ��� � �����" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 174, Description = "����������� ��� ��������", Description_45 = "����������� ��� ��������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 59, Description = "��������� ������� �� ���������� ������ � �����", Description_45 = "��������� ������� �� ���������� ������ � �����" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 187, Description = "��������� ������� �� ���������� ������ ���� ����������� ����������", Description_45 = "��������� ������� �� ���������� ������ ���� ����������� ����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 60, Description = "����� ������ ������������", Description_45 = "����� ������ ������������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 188, Description = "����� ������ �����������", Description_45 = "����� ������ �����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 61, Description = "����� ������ ��������", Description_45 = "����� ������ ��������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 189, Description = "����� ������ ����������", Description_45 = "����� ������ ����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 62, Description = "����� ������ ������������", Description_45 = "����� ������ ������������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 190, Description = "����� ������ �� ������������", Description_45 = "����� ������ �� ������������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 63, Description = "��������� ����������� �������", Description_45 = "��������� ����������� �������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 191, Description = "��� �������� � �����", Description_45 = "��� �������� � �����" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 64, Description = "������ �� FLASH-������ ���������", Description_45 = "������ �� FLASH-������ ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 192, Description = "������ �� FLASH-������ �� ���������", Description_45 = "������ �� FLASH-������ �� ���������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 47, Description = "�������� ������� ��� �.�. ����� ���� ��������, ��� ������� ������� ���������������", Description_45 = "�������� ������� ��� �.�. ����� ���� ��������, ��� ������� ������� ���������������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 175, Description = "�������� ������� ��� �.�. ����� ���� ��������, ��� ������� ������� ���������������", Description_45 = "�������� ������� ��� �.�. ����� ���� ��������, ��� ������� ������� ���������������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 65, Description = "�������� �������� ������ ����� ���� ����������� �����������", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 193, Description = "�������� �������� ������ ����� ���� ����������� �����������", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 66, Description = "����� ��������������� �������� � �����", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 194, Description = "����� ��������������� �������� �� � �����", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 67, Description = "�������� ����� ��������� ������", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 195, Description = "�������������� �������: ����������� �������� ������", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 68, Description = "�������������� �������: ����������� �������� ���������� ������", Description_45 = "" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 48, Description = "������ �������� � �����", Description_45 = "������ �������� � �����" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 176, Description = "������ �������� �����������", Description_45 = "������ �������� �����������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 49, Description = "����� ��� � �����", Description_45 = "����� ��� � �����" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 177, Description = "����� ��� ��������� ������", Description_45 = "����� ��� ��������� ������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 163, Description = "�������� �������� � ������", Description_45 = "�������� �������� � ������" });
            alarmsTypes.Add(new FloutecAlarmsTypes() { Code = 169, Description = "", Description_45 = "�������� ��������� ���" });

            alarmsTypes.ForEach((a) => { context.FloutecAlarmsTypes.AddOrUpdate(a); });

            #endregion

            #region ������������� ����� ������������ ��� ������������ �������

            List<FloutecIntersTypes> intersTypes = new List<FloutecIntersTypes>();

            intersTypes.Add(new FloutecIntersTypes() { Code = 0, Description = "������������ ������������", Description_45 = "������������ ������������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 1, Description = "���������, ��/�3", Description_45 = "���������, ��/�3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 2, Description = "�������� ���� ��2, %", Description_45 = "�������� ���� ��2, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 3, Description = "�������� ���� N2, %", Description_45 = "�������� ���� N2, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 4, Description = "������� ������������, ��", Description_45 = "������� ������������, ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 5, Description = "������� ��, ��", Description_45 = "������� ��, ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 6, Description = "����������� ��������, �� ��. ��.", Description_45 = "����������� ��������, �� ��. ��." });
            intersTypes.Add(new FloutecIntersTypes() { Code = 7, Description = "������� ��, ��/�2", Description_45 = "������� ��, ��/�2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 8, Description = "����������� ������ (Qmin), �3/���", Description_45 = "����������� ������ (Qmin), �3/���" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 9, Description = "��� ������� (Qmax), �3/���", Description_45 = "��� ������� (Qmax), �3/���" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 10, Description = "������������ �������", Description_45 = "������������ �������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 11, Description = "����� ������������ �������� ��������, ��/�2", Description_45 = "����� ������������ �������� ��������, ��/�2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 12, Description = "��� ������ �������� ��������", Description_45 = "��� ������ �������� ��������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 13, Description = "�������� ������� ��������", Description_45 = "�������� ������� ��������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 14, Description = "����� ���� �� 1 �������� �������, �3", Description_45 = "����� ���� �� 1 �������� �������, �3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 15, Description = "�������� ��������� ������� ������������", Description_45 = "���������� ���� �������� ��������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 16, Description = "���������� ���� ������� �������� ��������", Description_45 = "���������� ���� ������� �������� ��������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 17, Description = "����� ��������", Description_45 = "���������� ���� �������� �������� ��������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 18, Description = "�������� ����������, ���*�/�2", Description_45 = "�������� ����������, ���*�/�2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 19, Description = "������������� �����, ��", Description_45 = "������������� �����, ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 20, Description = "����������� �� (�0*1�-06) ��� ������� ���� ��", Description_45 = "����������� �� (�0*1�-06) ��� ������� ���� ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 21, Description = "����������� �� (�1*1�-09) ��� ������� ���� ��", Description_45 = "����������� �� (�1*1�-09) ��� ������� ���� ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 22, Description = "���� ��������� ���������", Description_45 = "���� ��������� ���������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 23, Description = "����������� �� (�2*1�-12) ��� ������� ���� ��", Description_45 = "����������� �� (�2*1�-12) ��� ������� ���� ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 24, Description = "���� ��������� �����", Description_45 = "���� ��������� �����" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 25, Description = "���������� ���������� ���������� �1", Description_45 = "���������� ���������� ���������� �1" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 26, Description = "���������� ���������� ���������� �2", Description_45 = "���������� ���������� ���������� �2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 27, Description = "���������� ���������� ���������� �3", Description_45 = "���������� ���������� ���������� �3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 28, Description = "����� �� ������ �����", Description_45 = "����� �� ������ �����" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 29, Description = "����� �� ������ �����", Description_45 = "����� �� ������ �����" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 30, Description = "����� - ������� �� ������", Description_45 = "����� - ������� �� ������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 31, Description = "����� - ������� �� ������", Description_45 = "����� - ������� �� ������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 32, Description = "����������� ��������", Description_45 = "����������� ��������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 33, Description = "����������� �� (�0*1�-06) ��� ������� ���� �����", Description_45 = "����������� �� (�0*1�-06) ��� ������� ���� �����" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 34, Description = "����������� �� (�1*1�-09) ��� ������� ���� �����", Description_45 = "����������� �� (�1*1�-09) ��� ������� ���� �����" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 35, Description = "����������� �� (�2*1�-12) ��� ������� ���� �����", Description_45 = "����������� �� (�2*1�-12) ��� ������� ���� �����" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 36, Description = "������� �������� ���. �3 ������ ��� �.�.", Description_45 = "������� ������� �� 10 ���. �3 ��� �.�. �� ������ 10000000" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 37, Description = "����� ��� �.�., �3", Description_45 = "����� ��� �.�. �� ������ 10000, �3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 38, Description = "��� ���", Description_45 = "��� ���" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 39, Description = "������ ��� ITABAR", Description_45 = "������ ��� ITABAR" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 40, Description = "������ ��� ANNUBAR", Description_45 = "������ ����� � �����, ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 41, Description = "������� ��������� ��������", Description_45 = "������� ��������� ��������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 42, Description = "������� ��������� �������� ��������", Description_45 = "������� ��������� �������� ��������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 43, Description = "������� ��������� ������������ ��������", Description_45 = "������� ��������� ������������ ��������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 44, Description = "��� ������������ ��������", Description_45 = "��� ������������ ��������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 45, Description = "������������� ������ ��� ������ ������", Description_45 = "������������� ������ ��� ������ ������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 46, Description = "������ ���������� ��� ��� ������", Description_45 = "������ ���������� ��� ��� ������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 47, Description = "������ ���������� ��� ��� ����������", Description_45 = "������ ���������� ��� ��� ����������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 48, Description = "��� �������� ��������, ���/�2", Description_45 = "��� �������� ��������, ���/�2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 49, Description = "��� ��������, ���/��2", Description_45 = "��� ��������, ���/��2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 50, Description = "��� ��������, ���/��2", Description_45 = "��� ��������, ���/��2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 51, Description = "��� �����������, ��", Description_45 = "��� �����������, ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 52, Description = "��� �����������, ��", Description_45 = "��� �����������, ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 53, Description = "���������� ��������� �� 1 �3", Description_45 = "���������� ��������� �� 1 �3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 54, Description = "����������� ��������� ��������, ���/��2", Description_45 = "����������� ��������� ��������, ���/��2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 55, Description = "������, ��� ������� ������� ���������������, �3/���", Description_45 = "������, ��� ������� ������� ���������������, �3/���" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 56, Description = "����������� ����������� ������ ��� �.�., �3/���", Description_45 = "����������� ����������� ������ ��� �.�., �3/���" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 57, Description = "����������� ��������� ������� ��������, ���/�2", Description_45 = "����������� ��������� ������� ��������, ���/�2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 58, Description = "��� �������� ��������, ���/�2", Description_45 = "��� �������� ��������, ���/�2" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 59, Description = "��� ���������", Description_45 = "��� ���������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 60, Description = "��� ���������", Description_45 = "��� ���������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 61, Description = "������������� ���� ��������� ������ �", Description_45 = "������������� ���� ��������� ������ �" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 62, Description = "������������� ���� ��������� ������ �", Description_45 = "������������� ���� ��������� ������ �" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 63, Description = "������������� ���� ��������� ������ ��", Description_45 = "������������� ���� ��������� ������ ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 64, Description = "������������� ���� ��������� ������ ���", Description_45 = "������������� ���� ��������� ������ ���" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 65, Description = "����������������� ������������� ���� ��������� ������ �", Description_45 = "����������������� ������������� ���� ��������� ������ �" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 66, Description = "����������������� ������������� ���� ��������� ������ �", Description_45 = "����������������� ������������� ���� ��������� ������ �" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 67, Description = "����������������� ������������� ���� ��������� ������ ��", Description_45 = "����������������� ������������� ���� ��������� ������ ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 68, Description = "����������������� ������������� ���� ��������� ������ ���", Description_45 = "����������������� ������������� ���� ��������� ������ ���" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 69, Description = "������������������� ������������� ���� ��������� ������ �", Description_45 = "������������������� ������������� ���� ��������� ������ �" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 70, Description = "������������������� ������������� ���� ��������� ������ �", Description_45 = "������������������� ������������� ���� ��������� ������ �" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 71, Description = "������������������� ������������� ���� ��������� ������ ��", Description_45 = "������������������� ������������� ���� ��������� ������ ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 72, Description = "������������������� ������������� ���� ��������� ������ ���", Description_45 = "������������������� ������������� ���� ��������� ������ ���" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 128, Description = "�����", Description_45 = "�����" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 129, Description = "������������� ����������� ���", Description_45 = "������������� ����������� ���" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 130, Description = "������ ����� ������, ���.", Description_45 = "������ ����� ������, ���." });
            intersTypes.Add(new FloutecIntersTypes() { Code = 131, Description = "����������� ���", Description_45 = "����������� ���" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 132, Description = "���������� ����������� ����� Re", Description_45 = "���������� ����������� ����� Re" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 133, Description = "��������� ���� ������ �", Description_45 = "��������� ���� ������ �" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 134, Description = "��������� ���� ������ �", Description_45 = "��������� ���� ������ �" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 135, Description = "��������� ���� ������ ��", Description_45 = "��������� ���� ������ ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 136, Description = "��������� ���� ������ ���", Description_45 = "��������� ���� ������ ���" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 137, Description = "��������� ���� ������ ���", Description_45 = "��������� ���� ������ ���" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 138, Description = "������ ����� � �����, ��", Description_45 = "��������� ������������ ����������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 139, Description = "����� ���������", Description_45 = "����� ���������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 141, Description = "���������� ���������", Description_45 = "���������� ���������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 142, Description = "��������� ������ ������� ������ ���������, ��", Description_45 = "��������� ������ ������� ������ ���������, ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 143, Description = "�������������� �������� ��", Description_45 = "�������������� �������� ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 144, Description = "���������� �� ���������", Description_45 = "���������� �� ���������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 145, Description = "������ � ���������", Description_45 = "������ � ���������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 146, Description = "��������� ����������", Description_45 = "��������� ����������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 147, Description = "�������� ��", Description_45 = "�������� ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 148, Description = "����������� ������� ��", Description_45 = "����������� ������� ��" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 149, Description = "�������� �", Description_45 = "�������� �" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 150, Description = "����������� ������� �", Description_45 = "����������� ������� �" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 151, Description = "��������� ����", Description_45 = "��������� ����" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 152, Description = "��������� ���", Description_45 = "��������� ���" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 153, Description = "��������� � (����������������� ���������)", Description_45 = "��������� � (����������������� ���������)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 154, Description = "��������� � (����������������� ���������)", Description_45 = "��������� � (����������������� ���������)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 155, Description = "��������� (����������������� ���������)", Description_45 = "��������� (����������������� ���������)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 156, Description = "��������� � (����������������� ���������)", Description_45 = "��������� � (����������������� ���������)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 157, Description = "��������� � (������������������� ���������)", Description_45 = "��������� � (������������������� ���������)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 158, Description = "��������� � (������������������� ���������)", Description_45 = "��������� � (������������������� ���������)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 159, Description = "��������� (������������������� ���������)", Description_45 = "��������� (������������������� ���������)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 160, Description = "��������� � (������������������� ���������)", Description_45 = "��������� � (������������������� ���������)" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 161, Description = "����� ��������, ��/��3", Description_45 = "����� ��������, ��/��3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 162, Description = "������������ ���� ��������, ��3", Description_45 = "������������ ���� ��������, ��3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 168, Description = "����� ��������, ��������������� ������ �����", Description_45 = "����� ������ �����������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 169, Description = "������ �� ����� ��������", Description_45 = "������ �� ����� ��������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 170, Description = "��������� ��������, �/��3", Description_45 = "��������� ��������, �/��3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 171, Description = "������������ ������������� ����, �/���. �3", Description_45 = "������������ ������������� ����, �/���. �3" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 172, Description = "�������� ���� ������ ��4, %", Description_45 = "�������� ���� ������ ��4, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 173, Description = "�������� ���� ����� �2�6, %", Description_45 = "�������� ���� ����� �2�6, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 174, Description = "�������� ���� ������� �3�8, %", Description_45 = "�������� ���� ������� �3�8, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 175, Description = "�������� ���� ������ �4�10, %", Description_45 = "�������� ���� ������ �4�10, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 176, Description = "�������� ���� ������� �5�12, %", Description_45 = "�������� ���� ������� �5�12, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 177, Description = "�������� ���� ������������ H2S, %", Description_45 = "�������� ���� ������������ H2S, %" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 178, Description = "��������� ���������������", Description_45 = "��������� ���������������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 179, Description = "���������� �� ���������", Description_45 = "���������� �� ���������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 180, Description = "������ � ���������", Description_45 = "������ � ���������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 181, Description = "��������� �", Description_45 = "��������� �" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 182, Description = "��������� �", Description_45 = "��������� �" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 183, Description = "���������", Description_45 = "���������" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 184, Description = "��������� �", Description_45 = "��������� �" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 185, Description = "����������� ����������� �������� ������, �/�", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 186, Description = "����� ��������� �������", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 187, Description = "����� ��������� ������", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 188, Description = "����� ��������� �������� ������", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 189, Description = "������� ������ �� ��������� MODBUS", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 190, Description = "����� ������ �� ��������� MODBUS", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 191, Description = "����� �������� ���������� ��������", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 192, Description = "����� �������� ���������� ������", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 193, Description = "����� ��������������� ��������", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 194, Description = "������� ������ ���������� � ������ ������� 6", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 195, Description = "������������ ����������� ������ �1", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 196, Description = "������������ ����������� ������ �2", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 197, Description = "������������ ����������� ������ �3", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 198, Description = "������� ����� ��", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 199, Description = "����� �����������", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 200, Description = "������� �������� ���. �3 � ���������� �������� �� ��������� ������", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 201, Description = "����� (������ 10 ���. �3) � ���������� �������� �� ��������� ������", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 202, Description = "������������ ����� ����������� ��", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 203, Description = "����� ���� �� 1 ������� ��� ����������� ������ �1, �3", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 204, Description = "����� ���� �� 1 ������� ��� ����������� ������ �2, �3", Description_45 = "" });
            intersTypes.Add(new FloutecIntersTypes() { Code = 205, Description = "����� ���� �� 1 ������� ��� ����������� ������ �3, �3", Description_45 = "" });

            intersTypes.ForEach((i) => { context.FloutecIntersTypes.AddOrUpdate(i); });

            #endregion

            #region ������������� ����� �������� ��� ������������ �������

            List<FloutecSensorsTypes> sensorsTypes = new List<FloutecSensorsTypes>();

            sensorsTypes.Add(new FloutecSensorsTypes() { Code = 1, Description = "���������" });
            sensorsTypes.Add(new FloutecSensorsTypes() { Code = 2, Description = "�������" });
            sensorsTypes.Add(new FloutecSensorsTypes() { Code = 3, Description = "�������� ����������" });

            sensorsTypes.ForEach((s) => { context.FloutecSensorsTypes.AddOrUpdate(s); });

            #endregion

            #region ������������� ����� ������� ������������ ROC809

            List<ROC809EventsTypes> eventsTypes = new List<ROC809EventsTypes>();

            eventsTypes.Add(new ROC809EventsTypes() { Code = 0, Description = "������� �����������" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 1, Description = "������� ��������� ���������" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 2, Description = "��������� �������" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 3, Description = "������� ������� ������������������ ������� (FST)" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 4, Description = "���������������� �������" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 5, Description = "������� ������ �������" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 6, Description = "������� ��������� �����" });
            eventsTypes.Add(new ROC809EventsTypes() { Code = 7, Description = "������� �������� ����������" });

            eventsTypes.ForEach((e) => { context.ROC809EventsTypes.AddOrUpdate(e); });

            List<ROC809EventsCodes> eventsCodes = new List<ROC809EventsCodes>();

            eventsCodes.Add(new ROC809EventsCodes() { Code = 144, Description = "������������������ �������������" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 145, Description = "��������� �� �������" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 146, Description = "������������� ���������� �� ���������" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 147, Description = "������ ����������� ����� ���" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 148, Description = "������������� ���� ������" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 150, Description = "���������������� FLASH-������" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 151, Description = "��������������� ��� ROC809" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 152, Description = "��������������� ��� ROC809" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 153, Description = "��������������� ��� ROC809" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 154, Description = "�������� SMART-������" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 155, Description = "����� SMART-������" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 200, Description = "��������� �����" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 248, Description = "��������� ���������" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 249, Description = "���������������� ��������" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 250, Description = "���������������� ��������" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 251, Description = "������� ����������" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 252, Description = "������ ����������" });
            eventsCodes.Add(new ROC809EventsCodes() { Code = 253, Description = "����� ���������������� ����������� ������ (MVS) � ��������� ����������" });

            eventsCodes.ForEach((e) => { context.ROC809EventsCodes.AddOrUpdate(e); });

            #endregion ������������� ����� ������ ������������ ROC809

            List<ROC809AlarmsTypes> rocAlarmsTypes = new List<ROC809AlarmsTypes>();

            rocAlarmsTypes.Add(new ROC809AlarmsTypes() { Code = 0, Description = "������ �����������" });
            rocAlarmsTypes.Add(new ROC809AlarmsTypes() { Code = 1, Description = "������ ���������" });
            rocAlarmsTypes.Add(new ROC809AlarmsTypes() { Code = 2, Description = "������ ������� ������������������ ������� (FST)" });
            rocAlarmsTypes.Add(new ROC809AlarmsTypes() { Code = 3, Description = "������ ����������������� ������" });
            rocAlarmsTypes.Add(new ROC809AlarmsTypes() { Code = 4, Description = "������ ����������������� ��������" });

            rocAlarmsTypes.ForEach((a) => { context.ROC809AlarmsTypes.AddOrUpdate(a); });

            List<ROC809AlarmsCodes> rocAlarmsCodes = new List<ROC809AlarmsCodes>();

            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 0, Description = "������ ������ ����������������� �������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 1, Description = "������ ������ ��������� �������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 2, Description = "������ ������� ����������������� �������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 3, Description = "������ ������� ��������� �������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 4, Description = "������ �������� ��������� ��������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 5, Description = "��������� �������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 6, Description = "������ ����� ���������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 7, Description = "������������ ���������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 8, Description = "������������ � ������ ������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 9, Description = "������������ ����������� ���������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 10, Description = "������������ �������� ������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 11, Description = "���������� ������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 12, Description = "����� '���������' ������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 13, Description = "������ ���������� � ��������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 14, Description = "������ ���������� ���������� RS-485" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 15, Description = "����� ���������� ������������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 16, Description = "������ ����������� ����������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 17, Description = "������������ �������� ������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 18, Description = "������ ������� �����������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 19, Description = "���� ������������������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 20, Description = "������� ���" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 21, Description = "������ ������������� ���������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 22, Description = "�������������� ������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 23, Description = "������ ����������� ����� �1" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 24, Description = "������ ����������� ����� �2" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 25, Description = "������������ ������ ����������� ������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 26, Description = "�������������� � ������������ ������ ����������� ������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 27, Description = "������������� ����" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 28, Description = "������ ����" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 29, Description = "����������� ������������ �������� �����" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 30, Description = "����������� ����������� �����" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 31, Description = "������ �������� ����� ����������� ������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 32, Description = "������ ������� ������ ���������" });
            rocAlarmsCodes.Add(new ROC809AlarmsCodes() { Code = 33, Description = "������ �������� ���������� �������" });

            rocAlarmsCodes.ForEach((a) => { context.ROC809AlarmsCodes.AddOrUpdate(a); });

            #region

            #endregion

            #region ������������� ���������

            List<Field> fields = new List<Field>();

            fields.Add(new Field() { DateCreated = DateTime.Now, DateModified = DateTime.Now, IsDeleted = false, Id = 1, Name = "SEM-SRV", Description = "���� ���������" });
            fields.Add(new Field() { DateCreated = DateTime.Now, DateModified = DateTime.Now, IsDeleted = false, Id = 2, Name = "OLEF-SRV", Description = "���� ����������" });
            fields.Add(new Field() { DateCreated = DateTime.Now, DateModified = DateTime.Now, IsDeleted = false, Id = 3, Name = "MACH-SRV", Description = "��� ������" });

            fields.ForEach((f) => { context.Fields.AddOrUpdate(f); });

            #endregion
        }
    }
}
