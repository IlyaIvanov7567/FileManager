# FileManager
:slightly_frowning_face: Приложение не поддерживает пробелы в адресах каталогов.

:slightly_smiling_face: Ожидается поставка в ближайших версиях.
#### Приложение позволяет:
- просматривать файловую структуру (как постранично так и всего содержимого заданого каталога)
- при постраничном выводе отображается текущая страница, количестов элементов на страницу, и общее количество элементов
- задавать пользовательское количество выводимых элементов на страницу (по умолчанию 10)
- просматривать свойства и атрибуты каталогов
- просматривать свойства и атрибуты файлов
- копировать каталоги
- копировать файлы с подтверждением перезаписи
- удалять каталоги
- удалять файлы

#### Дополнительно:
- приложение запоминает последнний рабочий каталог (даже во время нештатного завершения работы приложения) и при повторном запуске приложения можно продолжить работу с того места (каталога), на котором вы остановились
- приложение обрабатывает большинство исключительных ситуаций
- ведется логирование исключительных ситуаций

# Поддерживаемые команды
## help
Вывод доступных команд.

**Пример ввода:**
```bash
help
```

## cd
Вывод содержимого каталога.

Воспользуйтесь командой **cdp**, если необходимо произвести постраничный вывод содержимого.

**Аргументы:**
- target directory - каталог, содержимое которого необходимо вывести

**Пример ввода:**
```bash
cd D:\directory\
```
## cdp
Постраничный вывод содержимого каталог.
Количество отображаемых элементов на страницу настраивается в конфигурационном файле приложения. По умолчанию - 10 элементов на страницу.

Для изменения количества отображаемых элементов воспользуйтесь командой **setipp**.

Воспользуйтесь командой **cd**, если необходимо произвести вывод всего содержимого каталога.

**Arguments:**
- page number
- target directory

**Пример ввода:**
```bash
cdp 2 D:\directory\
```
## cdhome
Возврат в корневой каталог с выводом доступных дисков.

**Пример ввода:**
```bash
cdhome
```
## dirinfo
Вывод свойств и атрибутов каталога.

*note: Данная функция использует рекурсивный метод получения размера каталога. При большом количестве вложенний:*
- *подсчет размера каталога занимает вермя*
- *работа приложения может завершится ошибкой*

**Аргументы:**
- directory - каталог, атрибуты и свойства которого необходимо отобразить.

**Пример ввода:**
```bash
dirinfo D:\directory\
```
## dircopy
Копирует каталог и все вложения в новый каталог.
Если целевой каталог, несуществует, он будет создан.

**Аргументы:**
- source directory - каталог, который необходимо скопировать
- target directory - целевой каталог, в который производится копирование

**Аргументы:**
```bash
dircopy D:\sourcdirectory\ D:\targetdyrectory\
```

## dirdel
Удаляет каталог и все вложения.

**Аргументы:**
- directory - каталог, который необходимо удалить

**Пример ввода:**
```bash
dirdel D:\directory\
```
## fileinfo
Вывод свойств и атрибутов файла.

**Аргументы:**
- file - файл, свойства и атрибуты которого необходимо отобразит

**Пример ввода:**
```bash
fileinfo D:\file.txt
```

## filecopy
Копирует файл в новый каталог.

Если целевой каталог содержит файл, имя которого соответствует копируемому файлу, система запросит подвтерждение (y\n) на перезапись.

Если целевой каталог не существует, он будет создан.

**Аргументы:**
- source file - файл, который необходимо копировать
- target directory - целевой каталог, в который необходимо произвести копирование

**Пример ввода:**
```bash
filecopy D:\file.txt D:\targetdyrectory\
```

## filedel
Удаляет файл.

**Аргументы:**
- file - файл, который необходимо удалить

**Пример ввода:**
```bash
filedel D:\file.txt
```

## setipp
Устанавливает количество отображаемых элементов при постраничном просмотре содержимого каталога.

**Аргументы:**
- number - количество элементов 1..255

**Пример ввода:**
```bash
setipp 15
```

## exit
Выход из программы.

**Пример ввода:**
```bash
exit
```
