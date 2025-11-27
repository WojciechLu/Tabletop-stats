import { faXmark } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { JSX } from "react";

interface CreateSessionLogModalProps {
  onCloseModal: () => void;
  children: React.ReactNode | React.ReactNode[] | JSX.Element;
  title?: string;
}

const CreateSessionLogModal = ({
  onCloseModal,
  children,
  title,
}: CreateSessionLogModalProps) => {
    return (<div className="fixed top-0 left-0 w-full h-full flex items-center justify-center bg-gray-500 bg-opacity-70">
      <div className="bg-white rounded-md overflow-hidden max-w-md w-full mx-4">
        <nav className="bg-black text-white flex justify-between px-4 py-2">
          <span className="text-lg">{title}</span>
          <button
            className="bg-red-300 bg-opacity-50 py-1 px-2 hover:bg-red-500 hover:bg-opacity-70 transition-all rounded-full text-sm"
            onClick={onCloseModal}
          >
            &#10005;
          </button>
        </nav>
        <div className="py-8 pl-4">{children}</div>
      </div>
    </div>)
  return (
    <>
      <div
        className="fixed top-0 left-0 w-full h-full flex items-center justify-center bg-gray-500 bg-opacity-70"
        onClick={onCloseModal}
      />
      <div className="bg-white rounded-md overflow-hidden max-w-md w-full mx-4">
        <div className="bg-black text-white flex justify-between px-4 py-2">
          {/* {title && (
            <div className={styles.modalHeader}>
              <h5 className={styles.heading}>{title}</h5>
            </div>
          )} */}
          <button className="bg-red-300 bg-opacity-50 py-1 px-2 hover:bg-red-500 hover:bg-opacity-70 transition-all rounded-full text-sm" onClick={onCloseModal}>
            <FontAwesomeIcon icon={faXmark} style={{ marginBottom: "-3px" }} />
          </button>
          {children}
        </div>
      </div>
    </>
  );
};

export default CreateSessionLogModal;
