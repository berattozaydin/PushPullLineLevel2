PGDMP     .    '                {            TpHetrL3    15.3    15.3                 0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            !           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            "           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            #           1262    16403    TpHetrL3    DATABASE     ~   CREATE DATABASE "TpHetrL3" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Turkish_Turkey.1254';
    DROP DATABASE "TpHetrL3";
                postgres    false            �            1255    16511    addclothes(integer) 	   PROCEDURE     �   CREATE PROCEDURE public.addclothes(IN cs integer, OUT c_id integer)
    LANGUAGE plpgsql
    AS $$
DECLARE C_ID INT=0;
BEGIN

C_ID = 2+2;
c_id =C_ID;

END
$$;
 C   DROP PROCEDURE public.addclothes(IN cs integer, OUT c_id integer);
       public          postgres    false            �            1259    16414    Account    TABLE     o  CREATE TABLE public."Account" (
    "Id" integer NOT NULL,
    "CustomerId" integer,
    "Username" character varying,
    "Password" character varying,
    "Role" integer,
    "Name" character varying,
    "LastName" character varying,
    "CreateDati" date,
    "UpdateDati" date,
    "IsActive" integer,
    "Email" character varying,
    "PhoneNumber" integer
);
    DROP TABLE public."Account";
       public         heap    postgres    false            �            1259    16426    Customer    TABLE     �  CREATE TABLE public."Customer" (
    "CustomerId" integer NOT NULL,
    "CompanyName" character varying,
    "CompanyFullName" character varying,
    "TaxNumber" character varying,
    "TaxAdministration" character varying,
    "Remark" character varying(250),
    "CurrencyType" integer DEFAULT 0,
    "PartitionType" integer DEFAULT 0,
    "Status" integer DEFAULT 0,
    "Maturity" integer DEFAULT 0,
    "CompanyCode" character varying DEFAULT 0
);
    DROP TABLE public."Customer";
       public         heap    postgres    false            �            1259    16407    CustomerOrder    TABLE     G  CREATE TABLE public."CustomerOrder" (
    "CustomerOrderId" character varying NOT NULL,
    "CustomerId" integer NOT NULL,
    "CustomerOrderStatusId" integer NOT NULL,
    "OrderNumber" character varying NOT NULL,
    "Name" character varying,
    "Remark" character varying,
    "CreatedDate" date,
    "UpdatedDate" date
);
 #   DROP TABLE public."CustomerOrder";
       public         heap    postgres    false            �            1259    16449    CustomerOrderStatus    TABLE     �   CREATE TABLE public."CustomerOrderStatus" (
    "CustomerOrderStatusId" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);
 )   DROP TABLE public."CustomerOrderStatus";
       public         heap    postgres    false            �            1259    24613    event_alarm    TABLE       CREATE TABLE public.event_alarm (
    event_alarm_id integer NOT NULL,
    machine_name character varying,
    user_name character varying,
    log_description character varying NOT NULL,
    log_method character varying NOT NULL,
    dati timestamp with time zone
);
    DROP TABLE public.event_alarm;
       public         heap    postgres    false            �            1259    24620    event_alarm_event_alarm_id_seq    SEQUENCE     �   ALTER TABLE public.event_alarm ALTER COLUMN event_alarm_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.event_alarm_event_alarm_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    218                      0    16414    Account 
   TABLE DATA           �   COPY public."Account" ("Id", "CustomerId", "Username", "Password", "Role", "Name", "LastName", "CreateDati", "UpdateDati", "IsActive", "Email", "PhoneNumber") FROM stdin;
    public          postgres    false    215   $                 0    16426    Customer 
   TABLE DATA           �   COPY public."Customer" ("CustomerId", "CompanyName", "CompanyFullName", "TaxNumber", "TaxAdministration", "Remark", "CurrencyType", "PartitionType", "Status", "Maturity", "CompanyCode") FROM stdin;
    public          postgres    false    216   �$                 0    16407    CustomerOrder 
   TABLE DATA           �   COPY public."CustomerOrder" ("CustomerOrderId", "CustomerId", "CustomerOrderStatusId", "OrderNumber", "Name", "Remark", "CreatedDate", "UpdatedDate") FROM stdin;
    public          postgres    false    214   �$                 0    16449    CustomerOrderStatus 
   TABLE DATA           P   COPY public."CustomerOrderStatus" ("CustomerOrderStatusId", "Name") FROM stdin;
    public          postgres    false    217   �<                 0    24613    event_alarm 
   TABLE DATA           q   COPY public.event_alarm (event_alarm_id, machine_name, user_name, log_description, log_method, dati) FROM stdin;
    public          postgres    false    218   �=       $           0    0    event_alarm_event_alarm_id_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('public.event_alarm_event_alarm_id_seq', 27, true);
          public          postgres    false    219                       2606    16418    Account Account_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Account"
    ADD CONSTRAINT "Account_pkey" PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."Account" DROP CONSTRAINT "Account_pkey";
       public            postgres    false    215            |           2606    16413    CustomerOrder CustomerOrderId 
   CONSTRAINT     n   ALTER TABLE ONLY public."CustomerOrder"
    ADD CONSTRAINT "CustomerOrderId" PRIMARY KEY ("CustomerOrderId");
 K   ALTER TABLE ONLY public."CustomerOrder" DROP CONSTRAINT "CustomerOrderId";
       public            postgres    false    214            �           2606    16453 ,   CustomerOrderStatus CustomerOrderStatus_pkey 
   CONSTRAINT     �   ALTER TABLE ONLY public."CustomerOrderStatus"
    ADD CONSTRAINT "CustomerOrderStatus_pkey" PRIMARY KEY ("CustomerOrderStatusId");
 Z   ALTER TABLE ONLY public."CustomerOrderStatus" DROP CONSTRAINT "CustomerOrderStatus_pkey";
       public            postgres    false    217            �           2606    16437    Customer Customer_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."Customer"
    ADD CONSTRAINT "Customer_pkey" PRIMARY KEY ("CustomerId");
 D   ALTER TABLE ONLY public."Customer" DROP CONSTRAINT "Customer_pkey";
       public            postgres    false    216            �           2606    24619    event_alarm event_alarm_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.event_alarm
    ADD CONSTRAINT event_alarm_pkey PRIMARY KEY (event_alarm_id);
 F   ALTER TABLE ONLY public.event_alarm DROP CONSTRAINT event_alarm_pkey;
       public            postgres    false    218            �           1259    16443    fki_CustomerId    INDEX     N   CREATE INDEX "fki_CustomerId" ON public."Account" USING btree ("CustomerId");
 $   DROP INDEX public."fki_CustomerId";
       public            postgres    false    215            }           1259    16459    fki_CustomerOrderStatusId    INDEX     j   CREATE INDEX "fki_CustomerOrderStatusId" ON public."CustomerOrder" USING btree ("CustomerOrderStatusId");
 /   DROP INDEX public."fki_CustomerOrderStatusId";
       public            postgres    false    214            �           2606    16438    Account CustomerId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Account"
    ADD CONSTRAINT "CustomerId" FOREIGN KEY ("CustomerId") REFERENCES public."Customer"("CustomerId") NOT VALID;
 @   ALTER TABLE ONLY public."Account" DROP CONSTRAINT "CustomerId";
       public          postgres    false    216    3202    215            �           2606    16444    CustomerOrder CustomerId    FK CONSTRAINT     �   ALTER TABLE ONLY public."CustomerOrder"
    ADD CONSTRAINT "CustomerId" FOREIGN KEY ("CustomerId") REFERENCES public."Customer"("CustomerId") NOT VALID;
 F   ALTER TABLE ONLY public."CustomerOrder" DROP CONSTRAINT "CustomerId";
       public          postgres    false    216    3202    214            �           2606    16454 #   CustomerOrder CustomerOrderStatusId    FK CONSTRAINT     �   ALTER TABLE ONLY public."CustomerOrder"
    ADD CONSTRAINT "CustomerOrderStatusId" FOREIGN KEY ("CustomerOrderStatusId") REFERENCES public."CustomerOrderStatus"("CustomerOrderStatusId") NOT VALID;
 Q   ALTER TABLE ONLY public."CustomerOrder" DROP CONSTRAINT "CustomerOrderStatusId";
       public          postgres    false    217    214    3204               p   x�5�;�0��]y�뎖���ql)E��;i�4�� �Bێ��?�p��Bh�jw�1�� �Y̫��X9b�:�g�ؼ���_
����Q�Er����ݥ���\RJo,t!�         T   x�3��N,JI��,R�N,JL:�'[�=�<5'3�3*��ihf`fj`bf`�	Sg(��st~IjQfq&�W� $#�            x�}�_��dz���t����K����(��l �X|��N��r_|5b�1 U�coӴ����o_����u���׾}���y���������������?�����?����o?��۷/�������o������/?������ϟ?~���?~���_|��y����N�/?����~���?���o�����_��������)�����ϣ��ǎ.]Ə]�:��;z�u�?��:��٩@����B����\�Ƿq|+���8���c?
��9��z|���;>���y*����}�����}�����@��[q^��Xu�
��Xu���Xu>
��Xu>��Xu�
���2���R��Ǫ�\�����R��Ǫ�Z��Ǫ�V��Ǫ�^��Ǫ�Q��Ǫ�Y��Ǫ�U�����S���z|���z|��.z��l�z|��nz|���z|��z|���z|��^v|�nS��nz|���z|��-z|���z|��mz|���z|��z|���z|��]v|��S���z|���z|��/z|���z|��oz|���z|��z|���z|��_v��S��z|�z�z|�z,z|�z�z|�zlz|�z�z|�zz|�z�z|�z\v���S���z|�z�z|�z.z|�z�z|�znz|�z�z|�zz|�z�z|�z^v��^S��^z|�z�z|�z-z|�z�z|�zmz|�z�z|�zz|�z�z�Hp���TB���
�`�t�`0͍�,(K�++���
ib�]!OL{�+$��ht�L1����*��Q����D4�JIE������]a����
��FWX��R�����]a�;N���w�t���H5�
��P]a��ӕ�FWX?�
���	W��O����~t����+���]a��,�
Q든]a����O؂��~�t����+���]a��.�
�'vAWX?�����^P��'����k�+�� ]a�D0�
�'�AWX?1���	b��O���~�t��Ǡ*D�Ot���NWX?�����e��O0���?��]a��3�
�'�AWX?����hPb�'!���{�+���]a�D5�
�'�AWX?q�R�Hrot��٠+���]a��6�
���]a����Ox���~�t���+��]a��8�J�C���O����~�T�8�I�������
�'�AWX?����	u��O����~�t����+�c	g�+��xU!�}�+�u���	y��Õ��~�t����+���]a��=�
�'�AW�S�FS�|8ejt���
RI僮�A�T>�
VI僮���T>�
ZI僮���T>�
^I僮��T>�
�oN僮�����~*t��S��+���]a�T>�
��AWX?�����|��O僪���Jt���NW���FWX���ڠ+�Hm�ֿ?�6�
��Vt����������]a���k�����T>�
�/���~*t�|Dqit��S��+���]a�T>�
��AWX?�����|PZߜ�]a����O僮�~*t�|Humt��S��+���]a�T>�
��AWX?��B�S��+��u����|��O僮�~*t�|Lykt��S��+���]a�T>�
��AUh}s*t���NWX?�����|��O僮�~*t�|P}ot��S��+���]a�T>�
�oN僮����
��AWX?�����|��O僮�~*t�|U�ht��S��+���U��ͩ|��?;]a�T>�
��AWX?�����|��O僮�~*t�|Y�lt��S��*��9����W�+���]a�T>�
��AWX?�����|��O僮�~*t�|]�j4e��W��FW>(���եT>�
__J僮��T>�
_cJ僮�U�T>�
_gJ僮�T>�
_kJ僪���T>�
�?�
��AWX?�����|��O僮�~*t��S��+���]a�T>�
�oI僮����J�����
��AWX?�����|��O僮�~*t��S��+���U)_V���:�
�/�������AW�W�FWX����+�yu�ֿ��:�
��_bt���/������YU��-�|��_;]a�T>�
��AW�W��FWX?�����|��O僮�~*t��S��*��%����[�+���]a�T>�
��AWʗ׷FWX?�����|��O僮�~*T�ַ��AWX�t��S��+���]a�T>�
��AW���FWX?�����|��O僪���T>�
����~*t��S��+���]a�T>�
��AW�,�FWX?�����|PZߒ�]a����O僮�~*t��S��+���]a�T>�
��AW�#L�FWX?��B�[R��+�u����|��O僮�~*t��S��+���]a�T>�
��AW�Cl�FSVZ�:M��|P:]�6�|�j��]��6�|�n��]�7�|�r��]�A7�|�v��U����|����O僮�~*t��S��+���]a�T>�
��AWX?�����|PZߚ�]a��ӕ�0����O僮�~*t��S��+���]a�T>�
��AWX?��B�[S��+��t����|Е�8����O僮�~*t��S��+���]a�T>�
��AU�������k�+�?�n�ֿd7�Jy����
���t����������]a���v�������AUh}k*t���NWX?�����|��O僮�Gn���~*t��S��+���]a�T>�
�oM僮����
��AWX?�����|��O僮��Z�~*t��S��+���U����|��?:]a�T>�
��AWX?�����|��O僮�ǚ���~*t��S��*��5����g�+���]a�T>�
��AWX?�����|��O僮�۞���~*T�ַ��AWX��t��S��+���]a�T>�
��AWX?�����|��O僮�G_��l��m�]��t��c�S��+<�8����S��+<�8���c�S��+<�8����S��+<9��B��R��+���+���]a�T>�
��AWX?�����|��O僮�~*t��S��*��-����s�+��s�+���]a�T>�
��AWX?�����|��O僮�~*T�ַ��AWX�t��S��+�!�K�+���]a�T>�
��AWX?�����|��O僪���T>�
믝��~*t��S��+�5k�+���]a�T>�
��AWX?�����|P��R���������
��/�t���[����.])/��]a��E�������AWX�~�Š+���bPZߖ�]a����O僮�~*t��S��+���])�:�]a�T>�
��AWX?��B��R��+�t����|��O僮�~*t��S��+���])/�9]a�T>�
��AUh}[*t���NWX?�����|��O僮�~*t��S��+���])�;:]a�T>�
�oK僮����
��AWX?�����|��O僮�~*t��S��+���])/��M�i}�45��A�t��_��AWxV*t��`��AWxV*t��a��AWx!V*t��b��AWx1V*T�ַ��AWX�AWX?�����|��O僮�~*t��S��+���]a�T>�
��AUh}{*t���NWʋ��FWX?�����|��O僮�~*t��S��+���]a�T>�
�oO僮����
��AWʫ�FWX?�����|��O僮�~*t��S��+���U����|��_;]a�T>�
��AW��/�FWX?�����|��O僮�~*t��S��*��=����[�+���]a�T>�
��AW��O�FWX?�����|��O僮�~*T����~���+��w�����n]a�����������AWX�~���+��{�+�� w�ֿ_�;�
��/�T�ַ��AWX��t��S��+���]a�T>�
��AWX?��R^�|4����|��O僪���T>�
럝��~*t��S��+���]a�T>�
��AWX?��R^�}6����|PZߞ�]a�� �  ��O僮�~*t��S��+���]a�T>�
��AWX?��R^�~5�r���ijt���
�DO僮�Z�T>�
�FO僮�z�T>�
�HO僮��T>�
�JO僮��T>�
��H僮�����~*t��S��+���]a�T>�
��AWX?�����|��O僪���T>�
�ϝ��~*t��S��+���]a�T>�
��AWX?�����|��O僪���T>�
�/���~*t��S��+���]a�T>�
��AWX?�����|��O僪���T>�
믝��~*t��S��+���]a�T>�
��AWX?�����|��O僪���T>�
�o���~*t��S��+���]a�T>�
��AWX?�����|��O僪���T>�
��~*t��S��+���]a�T>�
��AWX?�����|��O僪���T>�
����~*t��S��+���]a�T>�
��AWX?�����|��O僪���T>�
럝��~*t��S��+���]a�T>�
��AWX?�����|��O僪���T>�
�_���~*t��S��+���]a�T>�
��AWX?�����|��O僦���3���A�teF�]YP�FWV��ѕekteG�]9P�FWN��ѕ�jT��w��AWX�AWX?�����|��O僮�~*t��S��+���]a�T>�
��AUh}g*t���NWX?�����|��O僮�~*t��S��+���]a�T>�
��AUh}g*t���NWX?�����|��O僮�~*t��S��+���]a�T>�
��AUh}g*t���NWX?�����|��O僮�~*t��S��+���]a�T>�
��AUh}g*t���NWX?�����|��O僮�~*t��S��+���]a�T>�
��AUh}g*t���NWX?�����|��O僮�~*t��S��+���]a�T>�
��AUh}g*t���NWX?�����|��O僮�~*t��S��+���]a�T>�
��AUh}g*t���NWX?�����|��O僮�~*t��S��+���]a�T>�
��AUh}g*t���NWX?�����|��O僮�~*t��S��+���]a�T>�
��AS.Zߕ�]��t�2�̍�,(K�++���ʆ�5���썮(G�+'���ʅr5�B�R��+���+���]a�T>�
��AWX?�����|��O僮�~*t��S��*��+����s�+���]a�T>�
��AWX?�����|��O僮�~*t��S��*��+����K�+���]a�T>�
��AWX?�����|��O僮�~*t��S��*��+����k�+���]a�T>�
��AWX?�����|��O僮�~*t��S��*��+����[�+���]a�T>�
��AWX?�����|��O僮�~*t��S��*��+����{�+���]a�T>�
��AWX?�����|��O僮�~*t��S��*��+����G�+���]a�T>�
��AWX?�����|��O僮�~*t��S��*��+����g�+���]a�T>�
��AWX?�����|��O僮�~*t��S��*��+����W�+���]a�T>�
��AWX?�����|��O僮�~*t��S��)��ؗ_�ˋ�)����E��m)��hk����Eۊ�=./�^��qyю��ˋv�|\^��h���ڧ�%��qy��]�./Z�K>��򢕻�<./Z�K>��򢕻�=./Z�K>��򢕻�s<./Z�K>��򢕻�s=.���.����E+w����h�.����E+wɼ<./Z�K��qy��]2o�ˋV�y\^�r����򢕻d>���%�������d����%��򢕻d����%��h�.Y���E+wɲ=./Z�K��qy��]��ˋV��|\^�r�,����Z�uz\^�r���ˋV�u~\^�r����򢕻d]���%����h�.Y���E+w�z<./Z�K��qy��]�^��k[�K��q���������0:         �   x�%̽� @��n
&���� E�S�9	
� l"yV0;�^v���{J�y��6P�-��S�k��u�^��ic򮖖�W�\jaQ���8m�"��a%mY[��Ǝ��Z�&a4�ٜh�OĻ���M"�r2          �  x����j�0���{/�K#�n�-%�B�[ lcɶlӷ�/VY��rȡ�Z?,٦��/o�>/v�o���t\�N7SB�o�/�Z�0-n��2c���>��}����� ӗ��y{�������|u^��t�i���`dYڻ�J��J���
�A�K$oU�=`L*�����ZQ��Lv�0�',	e���˾��be��ہ��W��*���I�|ߧ��;����k0ߦ/Ci����SGu���^� if+ݏK_�ۣ
�dݏk�?���+����?W,��	�>��o��JCʘ��r��w�������������6�6��xyұ��qk~��B�q��)���,\h䅃��몂e��yS�� ����_���[耥�\��ڟ����y�E��B     