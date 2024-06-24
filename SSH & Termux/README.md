# SSH & termux
>[!IMPORTANT]
>Instalar termux solo desde la play store

>[!NOTE]
>EN TU TELEFONO
>1. *Actualizar el pkg `pkg upgradepkg` *==> para que todos los paquetes que descargados esten actualizados*
>2. *Instala el servidor SSH `pkg install openssh` *==> para poder acceder de manera remota al telefono*
>3. *Instalar net tools `pkg install net-tools` *==> para poder descubrir la ip del telefono*
>4. *Instalar procps `pkg install procps` *==> para supervisar y detener procesos del sitema*
>5. *Instalar nano `pkg install nano` *==> para poder editar archivos dentro de la terminal*
>6. *Dar permisos de storage `termux-setup-storage` *==> debes aceptar los permisos*

>[!NOTE]
>OBTENER Y CONFIGURAR CREDENCIALES
>1. `ifconfig` *para poder descubrir la ip del telefono: ejemplo de salida `inet 192.168.1.35`*
>2. `whoami` *para descubrir el usuario: ejemplo de salida : `u0_345`*
>3. `passwd` *para configurar un nuevo password*

>[!NOTE]
>INICAIR Y DETENR EL DEMONIO SSH
>1. `sshd` Inicia del demonio ssh para poder conectarte de manera remota
>2. `pkill sshd` Detiene el servicio de ssh cuando dejamos de usar el servicio
>3. nota, el serviodor ssh expone el pueto `8022`

>[!NOTE]
>INGRESAR DE MANERA REMOTA AL DISPOSITIVO ANDROID,
>PUEDES HACERLO DESDE LA TERMINAL POWER SHELL DE WINDOWS
>
>*RECUERDA QUE TANTO EL TELEFONO COMO LA PC DEBEN ESTAR EN LA MISMA RED(conectados al mismo router o wifi)
> 1. Para conectarte al telefono de manera remota`ssh -p 8022 [usuario]@[ip]`.
> *recuerda reemplazar`[usuario]` e `[ip]` con el usuario e ip que descubriste en los pasos anteriores:
> un ejemplo de conexion sería `ssh -p 8022 u0_a383@192.168.1.35`*
>2. Ingresa la contraseña que configuraste
>4. ya estas dentro del telefono

>[!NOTE]
>CONFIGURAR CONEXION SIN CONTRASEÑA
>1. Cierra y vuele a abrir powershell(notaras que la conexion que hiciste al telefono se perdio)
>2. Genera las claves ssh `ssh-keygen` (si te pide confirmar presionas enter)
>3. Las calves se generaran en una carpeta llamada .ssh, para acceder a ella
>   usaremos  `cd .ssh` y luego `ls` para listar todo lo que se encuentra dentro de la carpeta
>4. Dentro de la carpeta sen encuentra un archivo llamado `id_rsa.pub`, para ingresar al archivo `notepad id_rsa.pub`
>5. Copia la calve con `ctrl + c`
>6. Conectate al telefono usando el comando `ssh -p 8022 [usuario]@[ip]` (ahora estas dentro del telefono)
>7. Crea un archivo llamado authorized_keys usa el comando `touch ~/.ssh/authorized_keys`
>8. Dale permisos ese directorio `chmod 600 ~/.ssh/authorized_keys` y `chmod 700 ~/.ssh`
>9. Copiaremos nuestra clave publica dentro de authorized_keys
> primero ingresaremos a .ssh con el comando `cd .ssh` luego ingresaremos al archivo con el comando
>`nano authorized_keys`
>10. Pega la llave publica dentro del archivo
>11. Guarda el archivo con `ctrl + o`
>12. Confirma los cambios con enter
>13. sale de archivo con `ctrl + x`

>[!NOTE]
>CONECTARSE SIN UTILIZAR LA CONTRASEÑA
>1. Cierra la terminal powwer shell
>2. Iniacia una nueva terminal(notaras que la conexion al telefono se cerró)
>3. Conectate al telefono `ssh -p 8022 [usuario]@[ip]`
>4. No te pedira que ingrese la contraseña
>5. Estas dentro del telefono 
